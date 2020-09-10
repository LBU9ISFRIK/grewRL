using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using MLAgents;

public class OpenAIAntAgent : MarathonAgent
{
    public Vector3 target;
    public override void AgentReset()
    {
        try
        {
            torso.Clear();
            configurableJoints.Clear();
            collisionSensors.Clear();

            _hasValidModel = false;

            target = transform.position;
            target.x += 1000f;

            base.AgentReset();

            if (torso.Count <= 0)
            {
                foreach (Transform child in transform)
                {
                    if (child.name.Contains("torso_geom")
                        //|| child.name.Contains("head") 
                        //|| child.name.Contains("tail")
                        )
                    {
                        torso.Add(child);
                    }
                }
            }

            Actions = new List<float>();
            for (int i = 0; i < MarathonJoints.Count; i++)
            {
                Actions.Add(0f);
            }

            beforeAngle = new float[MarathonJoints.Count];
        }
        catch (Exception e)
        {
            BodyParts["pelvis"] = GetComponentsInChildren<Rigidbody>().FirstOrDefault(x => x.name == "torso_geom");
            //throw;
        }

        // set to true this to show monitor while training
        Monitor.SetActive(true);

        //StepRewardFunction = StepRewardAnt101;
        //StepRewardFunction = StepRewardAnt_My;
        StepRewardFunction = StepRewardAnt_PyBullet;

        //TerminateFunction = TerminateAnt;
        TerminateFunction = TerminateAnt_My;

        ObservationsFunction = ObservationsDefault;

        BodyParts["pelvis"] = GetComponentsInChildren<Rigidbody>().FirstOrDefault(x => x.name == "torso_geom");
        SetupBodyParts();

        init_y = BodyParts["pelvis"].transform.position.y;
    }


    public override void AgentOnDone()
    {
    }

    float init_y;
    float[] beforeAngle;
    void ObservationsDefault()
    {
        var pelvis = BodyParts["pelvis"];
        #region origin
        //AddVectorObs(pelvis.velocity); //3
        //AddVectorObs(pelvis.transform.forward); // gyroscope //3
        //AddVectorObs(pelvis.transform.up); //3

        //AddVectorObs(SensorIsInTouch); //xml 센서 수
        ////string str = "";
        ////for (int i = 0; i < SensorIsInTouch.Count; i++)
        ////{
        ////    str += SensorIsInTouch[i] + ", ";
        ////}
        ////print(str);

        //JointRotations.ForEach(x => AddVectorObs(x)); //xml actuator 수 * 4
        //AddVectorObs(JointVelocity); //xml actuator 수

        ////수집한 observation이 brain에서 요구하는 observation size보다 적을 경우 0으로 채우기
        ////brain.brainParameters.vectorObservationSize;
        ////while(info.vectorObservation.Count < brain.brainParameters.vectorObservationSize)
        ////{
        ////    AddVectorObs(0f);
        ////}
        #endregion

        if(collectStateList.Count <= 0)
        {
            #region pybullet
            //more //8
            float torso_height = Mathf.Abs(pelvis.transform.position.y - init_y);
            AddVectorObs(torso_height);

            float self_walk_target_theta = Mathf.Atan2(target.z - pelvis.transform.position.z, target.x - pelvis.transform.position.x);
            float yaw = GetAngle(pelvis.transform.localEulerAngles.y) * Mathf.Deg2Rad;
            float angle_to_target = self_walk_target_theta - yaw;
            //print(self_walk_target_theta + ", " + yaw);
            float sin = Mathf.Sin(angle_to_target);
            float cos = Mathf.Cos(angle_to_target);
            //print(sin + ", " + cos);
            AddVectorObs(sin);
            AddVectorObs(cos);

            AddVectorObs(pelvis.velocity * 0.3f);

            float pitch = GetAngle(pelvis.transform.localEulerAngles.x) * Mathf.Deg2Rad;
            float roll = GetAngle(pelvis.transform.localEulerAngles.z) * Mathf.Deg2Rad;

            float clampedAngleX = Mathf.Clamp(pitch, -5f, 5f);
            //float clampedAngleY = Mathf.Clamp(yaw, -5f, 5f);
            float clampedAngleZ = Mathf.Clamp(roll, -5f, 5f);

            AddVectorObs(clampedAngleX);
            //AddVectorObs(clampedAngleY);
            AddVectorObs(clampedAngleZ);

            //j //16
            for (int i = 0; i < configurableJoints.Count; i++)
            {
                float lowerLimit = configurableJoints[i].lowAngularXLimit.limit * Mathf.Deg2Rad;
                float upperLimit = configurableJoints[i].highAngularXLimit.limit * Mathf.Deg2Rad;

                //float pos = MarathonJoints[i].Joint.transform.position.x;
                float pos = lowerLimit + (upperLimit - lowerLimit) * (Actions[i] + 1f) * 0.5f;
                float pos_mid = 0.5f * (lowerLimit + upperLimit);
                pos = 2 * (pos - pos_mid) / (upperLimit - lowerLimit);

                //float vel = JointVelocity[i];// = self.get_state()
                float vel = pos - beforeAngle[i] / Time.fixedDeltaTime;
                vel *= 0.1f;

                AddVectorObs(pos); //각도
                AddVectorObs(vel); //각속도

                beforeAngle[i] = pos;
                //print("pos : " + pos + "  vel : " + vel);
            }

            //feet_contact //4
            //string str = "";
            for (int i = 0; i < collisionSensors.Count; i++)
            {
                AddVectorObs(collisionSensors[i].isCollision); //지면 접촉 여부
                                                               //if (collisionSensors[i].isCollision)
                                                               //    str += collisionSensors[i].name + ", ";
            }
            //print(str);
            #endregion
        }

        #region CSONG
        foreach (var item in collectStateList)
        {
            item.collectState(item.index);
        }

        print(info.vectorObservation.Count);

        int remain = brain.brainParameters.vectorObservationSize - info.vectorObservation.Count;
        //int remain = 38 - info.vectorObservation.Count;
        for (int i = 0; i < remain; i++)
        {
            AddVectorObs(0f);
        }
        #endregion
    }

    bool TerminateAnt()
    {
        var angle = GetForwardBonus("pelvis");
        bool endOnAngle = (angle < .2f);
        return endOnAngle;
    }

    [SerializeField] List<Transform> torso = new List<Transform>();
    bool TerminateAnt_My()
    {
        bool done = false;
        //for (int i = 0; i < torso.Count; i++)
        //{
        //    //float angle = GetAngle(torso[i].localEulerAngles.y);

        //    if (torso[i].localPosition.y <= 0.26f// || torso[i].localPosition.y > 1.0f
        //    //|| torso[i].localPosition.z < -3f || torso[i].localPosition.z > 3f
        //    //|| angle < -20f || angle > 20f
        //    )
        //    {
        //        done = true;
        //        break;
        //        //print("done");
        //    }
        //}

        return done;
    }

    float StepRewardAnt101()
    {
        float velocity = GetVelocity();
        float effort = GetEffort();
        var effortPenality = 0.5f * (float)effort;
        var jointsAtLimitPenality = GetJointsAtLimitPenality() * 4;

        var reward = velocity
                     - jointsAtLimitPenality
                     - effortPenality;
        if (ShowMonitor)
        {
            var hist = new[] { reward, velocity, -jointsAtLimitPenality, -effortPenality }.ToList();
            Monitor.Log("rewardHist", hist.ToArray());
        }

        //print("velocity : " + velocity);
        //print("effort : " + effort);
        //print("jointsAtLimitPenality : " + jointsAtLimitPenality);
        return reward;
    }

    float beforeVelocity;
    float StepRewardAnt_My()
    {
        float actionSquSum = 0f;
        for (int i = 0; i < Actions.Count; i++)
        {
            actionSquSum += Actions[i] * Actions[i];
        }

        float forward_reward = GetVelocity();   //속도(단위 시간당 나아간 거리)
        float ctrl_cost = 0.5f * actionSquSum;  //액션 배열 원소들의 제곱의 합
        float contact_cost = 0f;                //0.5 * 1e-3 * np.sum(np.square(np.clip(self.sim.data.cfrc_ext, -1, 1)))
                                                //The cfrc_ext are the external forces (force x,y,z and torque x,y,z) applied to each of the links at the center of mass. For the Ant, this is 14*6: the ground link, the torso link, and 12 links for all legs (3 links for each leg).
                                                //https://github.com/openai/gym/issues/585 
                                                //원본에선 항상 0
        float survive_reward = 1.0f;            //상수

        //float accel = forward_reward - beforeVelocity;
        //accel = Mathf.Abs(accel);

        //beforeVelocity = forward_reward;

        float reward = forward_reward - ctrl_cost - contact_cost + survive_reward;

        //reward -= accel;
        //print(accel);

        return reward;
    }

    //float beforeTargetDist = 0f;
    float StepRewardAnt_PyBullet()
    {
        //print(Time.frameCount + " reward");
        //생존 보너스
        //float alive_bonus = 1f; //상수
        //if (torso[0].localPosition.y <= 0.26f)
        //{
        //    alive_bonus = -1f;
        //    //print("-1");
        //}

        //속도 보너스
        float progress = GetVelocity();

        //float targetDist = new Vector2(target.z - BodyParts["pelvis"].transform.position.z, target.x - BodyParts["pelvis"].transform.position.x).magnitude;
        //float progress = (beforeTargetDist - targetDist) / Time.fixedDeltaTime;
        //print(targetDist + ", " + beforeTargetDist + ", " + progress + ", " + GetVelocity());
        //beforeTargetDist = targetDist;

        //action 페널티
        const float self_electricity_cost = -2f;
        float actionAbsSum = 0f;
        const float self_stall_torque_cost = -0.1f;
        float actionSqrSum = 0f;
        for (int i = 0; i < Actions.Count; i++)
        {
            actionAbsSum += Mathf.Abs(Actions[i] * JointVelocity[i]);
            actionSqrSum += Actions[i] * Actions[i];
        }
        float absMean = actionAbsSum / Actions.Count;
        float sqrMean = actionSqrSum / Actions.Count;
        float electricity_cost = self_electricity_cost * absMean + self_stall_torque_cost * sqrMean;
        electricity_cost = Mathf.Clamp(electricity_cost, -1f, 1f);

        //joint stuck 페널티
        const float self_joints_at_limit_cost = -0.1f;
        int joints_at_limit = 0;
        for (int i = 0; i < configurableJoints.Count; i++)
        {
            float lowerLimit = configurableJoints[i].lowAngularXLimit.limit * Mathf.Deg2Rad;
            float upperLimit = configurableJoints[i].highAngularXLimit.limit * Mathf.Deg2Rad;

            //float pos = MarathonJoints[i].Joint.transform.position.x;
            float pos = lowerLimit + (upperLimit - lowerLimit) * (Actions[i] + 1f) * 0.5f;
            float pos_mid = 0.5f * (lowerLimit + upperLimit);
            pos = 2 * (pos - pos_mid) / (upperLimit - lowerLimit);

            if (Mathf.Abs(pos) > 0.99f)
                joints_at_limit++;
        }
        float joints_at_limit_cost = self_joints_at_limit_cost * joints_at_limit;

        //접촉 페널티
        float feet_collision_cost = 0f; //상수

        //float reward = alive_bonus + progress + electricity_cost + joints_at_limit_cost + feet_collision_cost;
        float reward = progress + electricity_cost + joints_at_limit_cost + feet_collision_cost;
        //float reward = progress;

        //print(string.Format("alive_bonus : {0}, progress : {1}, electricity_cost : {2}, joints_at_limit_cost : {3}, reward : {4}", alive_bonus, progress, electricity_cost, joints_at_limit_cost, reward));
        //print("reward : " + reward);

        return reward;
    }
}
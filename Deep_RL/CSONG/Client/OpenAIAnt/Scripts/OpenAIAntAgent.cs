using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using MLAgents;


namespace ModelLoader
{
    namespace Samples
    {
        public class OpenAIAntAgent : MarathonAgent
        {
            public Client client;
            public string goal;
            public string str_reward;
            public override void AgentReset()
            {

                goal = client.goal;
                str_reward = client.reward;

                base.AgentReset();

                // set to true this to show monitor while training
                Monitor.SetActive(true);

                

                switch (str_reward)
                {
                    case "Reward1":
                        StepRewardFunction = StepRewardAnt_1;
                        break;
                    case "Reward2":
                        StepRewardFunction = StepRewardAnt_2;
                        break;
                    case "Reward3":
                        StepRewardFunction = StepRewardAnt_3;
                        break;
                    case "Reward4":
                        StepRewardFunction = StepRewardAnt_4;
                        break;
                    default:
                        StepRewardFunction = StepRewardAnt_1;
                        break;
                }


                switch (goal)
                {
                    case "Goal1":
                        TerminateFunction = TerminateAnt_Goal1;
                        break;
                    case "Goal2":
                        TerminateFunction = TerminateAnt_Goal2;
                        break;
                    case "Goal3":
                        TerminateFunction = TerminateAnt_Goal3;
                        break;
                    case "Goal4":
                        TerminateFunction = TerminateAnt_Goal4;
                        break;
                    default:
                        TerminateFunction = TerminateAnt_Goal1;
                        break;
                }

                ObservationsFunction = ObservationsDefault;

                BodyParts["pelvis"] = GetComponentsInChildren<Rigidbody>().FirstOrDefault(x => x.name == "torso_geom");
                SetupBodyParts();
            }


            public override void AgentOnDone()
            {
            }

            void ObservationsDefault()
            {
                if (ShowMonitor)
                {
                }

                var pelvis = BodyParts["pelvis"];
                AddVectorObs(pelvis.velocity);
                AddVectorObs(pelvis.transform.forward); // gyroscope 
                AddVectorObs(pelvis.transform.up);

                AddVectorObs(SensorIsInTouch);
                JointRotations.ForEach(x => AddVectorObs(x));
                AddVectorObs(JointVelocity);
            }

            bool TerminateAnt_Goal1()
            {
                var angle = GetForwardBonus("pelvis");
                bool endOnAngle = (angle < .2f);
                return endOnAngle;
            }

            bool TerminateAnt_Goal2()
            {
                var angle = GetForwardBonus("pelvis");
                bool endOnAngle = (angle < .15f);
                return endOnAngle;
            }
            bool TerminateAnt_Goal3()
            {
                var angle = GetForwardBonus("pelvis");
                bool endOnAngle = (angle < .1f);
                return endOnAngle;
            }
            bool TerminateAnt_Goal4()
            {
                var angle = GetForwardBonus("pelvis");
                bool endOnAngle = (angle < .05f);
                return endOnAngle;
            }

            float StepRewardAnt_1()
            {
                float velocity = GetVelocity();
                float effort = GetEffort();
                var effortPenality = 0.6f * (float)effort;
                var jointsAtLimitPenality = GetJointsAtLimitPenality() * 4;
                var reward = velocity
                             - jointsAtLimitPenality
                             - effortPenality;
                if (ShowMonitor)
                {
                    var hist = new[] { reward, velocity, -jointsAtLimitPenality, -effortPenality }.ToList();
                    Monitor.Log("rewardHist", hist.ToArray());
                }
                return reward;
            }
            float StepRewardAnt_2()            {
                float velocity = GetVelocity();
                float effort = GetEffort();
                var effortPenality = 0.4f * (float)effort;
                var jointsAtLimitPenality = GetJointsAtLimitPenality() * 4;

                var reward = velocity
                             - jointsAtLimitPenality
                             - effortPenality;
                if (ShowMonitor)
                {
                    var hist = new[] { reward, velocity, -jointsAtLimitPenality, -effortPenality }.ToList();
                    Monitor.Log("rewardHist", hist.ToArray());
                }
                return reward;
            }
            float StepRewardAnt_3()            {
                float velocity = GetVelocity();
                float effort = GetEffort();
                var effortPenality = 0.7f * (float)effort;
                var jointsAtLimitPenality = GetJointsAtLimitPenality() * 4;

                var reward = velocity
                             - jointsAtLimitPenality
                             - effortPenality;
                if (ShowMonitor)
                {
                    var hist = new[] { reward, velocity, -jointsAtLimitPenality, -effortPenality }.ToList();
                    Monitor.Log("rewardHist", hist.ToArray());
                }
                return reward;
            }
            float StepRewardAnt_4()
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
                return reward;
            }
        }
    }
}
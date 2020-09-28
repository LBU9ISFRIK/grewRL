using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text;
using System.Net;
using System.Net.Sockets;
using MLAgents;

public class Client : MonoBehaviour
{
    public struct UdpState
    {
        public UdpClient udpClient;
        public IPEndPoint remoteEP;
    }

    string strIP = "127.0.0.1";
    int port = 8000;

    UdpClient udpClient;
    IPEndPoint remoteEP;
    UdpState udpState = new UdpState();

    byte[] data;

    public MarathonAcademy marathonAcademy;
    public Brain brain;
    public MarathonSpawner[] marathonSpawners;
    private MarathonAgent[] marathonAgents;

    int leg_count;

    void Start()
    {
        marathonAgents = new MarathonAgent[marathonSpawners.Length];
        for (int i = 0; i < marathonAgents.Length; i++)
        {
            marathonAgents[i] = marathonSpawners[i].GetComponent<MarathonAgent>();
        }

        remoteEP = new IPEndPoint(IPAddress.Parse(strIP), port);
        udpClient = new UdpClient(remoteEP);
        udpClient.Client.Blocking = false;
        udpClient.Client.ReceiveTimeout = 1000;

        udpState.udpClient = udpClient;
        udpState.remoteEP = remoteEP;

        //udpClient.Client.Bind(remoteEP);

        //udpClient.BeginReceive(new System.AsyncCallback(ReceiveCallback), udpState); //한번만 받음(비동기)

        while (udpClient.Available > 0)
        {
            // receive bytes
            data = udpClient.Receive(ref remoteEP);
            print("clear data : " + Encoding.Default.GetString(data));
        }

        StartCoroutine(ReceiveData());
    }

    void Update()
    {
        //data = udpClient.Receive(ref remoteEP); //받을때까지 멈춤(동기)
        //print(string.Format("{0} : 수신 : {1}", remoteEP.ToString(), Encoding.Default.GetString(data)));
    }

    private void OnDestroy()
    {
        udpClient.Close();
    }

    IEnumerator ReceiveData()
    {
        while (true)
        {
            try
            {
                if (udpClient.Available > 0)
                {
                    // receive bytes
                    data = udpClient.Receive(ref remoteEP);
                    string str = Encoding.Default.GetString(data);

                    string[] sp = str.Split('$');
                    for (int i = 0; i < sp.Length; i++)
                    {
                        //print(sp[i]);
                        if (sp[i].Contains("LegCount"))
                            ChangeXML(sp[i]);
                        else if (sp[i].Contains("StateType"))
                            ChangeState(sp[i]);
                        else if (sp[i].Contains("Agent"))
                            ChangeGoal(sp[i]);
                    }
                }
            }
            catch (System.Exception err)
            {
                //print(err.ToString());
            }

            yield return new WaitForEndOfFrame();
        }
    }

    public void ChangeXML(string str) //LegCount:6
    {
        string[] split = str.Split(':');
        foreach (var item in split)
        {
            if (int.TryParse(item, out leg_count))
            {
                //brain.brainParameters.vectorObservationSize = 8 + leg_count * 5;
                //brain.brainParameters.vectorActionSize[0] = leg_count * 2;

                for (int i = 0; i < marathonSpawners.Length; i++)
                {
                    //string xmlPath = string.Format("N/pybullet_ant_{0}", leg_count); //TODO : 해당 파일 없을 경우 처리
                    string xmlPath = string.Format("N/unity_oai_ant_{0}", leg_count); //TODO : 해당 파일 없을 경우 처리
                    TextAsset asset = Resources.Load<TextAsset>(xmlPath);

                    if (marathonSpawners[i].Xml == asset)
                        return;

                    marathonSpawners[i].Xml = asset;
                    marathonAgents[i].AgentReset();
                }

                //marathonAcademy.InitializeEnvironment();
                try
                {
                    marathonAcademy.UpdateBrainParameters();
                }
                catch (System.Exception)
                {
                    
                }
                
                marathonAcademy.enabled = true;

                return;
            }
        }
    }

    public void ChangeState(string str) //StateType,position:0,position:1,position:2,rotation:0,
    {
        foreach (var agent in marathonAgents)
            agent.collectStateList.Clear();

        str = str.Replace("StateType", ""); //,position:0,position:1,position:2,rotation:0,

        string[] split = str.Split(','); //position:0 position:1 position:2 rotation:0
        foreach (string item in split)
        {
            if (item == "")
                continue;

            string[] split2 = item.Split(':');
            string category = split2[0];
            int xyz = int.Parse(split2[1]);

            foreach (var agent in marathonAgents)
            {
                if (category.Equals(MarathonAgent.E_STATE.position.ToString()))
                {
                    agent.collectStateList.Add(new MarathonAgent.CollectStateStruct(agent.CollectPosition, xyz));
                }
                else if (category.Equals(MarathonAgent.E_STATE.rotation.ToString()))
                {
                    agent.collectStateList.Add(new MarathonAgent.CollectStateStruct(agent.CollectRotation, xyz));
                }
                else if (category.Equals(MarathonAgent.E_STATE.velocity.ToString()))
                {
                    agent.collectStateList.Add(new MarathonAgent.CollectStateStruct(agent.CollectVelocity, xyz));
                }
                else if (category.Equals(MarathonAgent.E_STATE.angularVelocity.ToString()))
                {
                    agent.collectStateList.Add(new MarathonAgent.CollectStateStruct(agent.CollectAngularVelocity, xyz));
                }
                else if (category.Equals(MarathonAgent.E_STATE.joint_angle.ToString()))
                {
                    agent.collectStateList.Add(new MarathonAgent.CollectStateStruct(agent.CollectJointAngle, 0));
                }
                else if (category.Equals(MarathonAgent.E_STATE.joint_angularVelocity.ToString()))
                {
                    agent.collectStateList.Add(new MarathonAgent.CollectStateStruct(agent.CollectJointAngularVelocity, 0));
                }
                else if (category.Equals(MarathonAgent.E_STATE.joint_collisionSensor.ToString()))
                {
                    agent.collectStateList.Add(new MarathonAgent.CollectStateStruct(agent.CollectJointCollisionSensors, 0));
                }
            }
        }
    }

    public void ChangeGoal(string str) //Agent:1,Goal:1
    {
        string[] split = str.Split(',');

        string agent = split[0]; //Agent:1
        string goal = split[1]; //Goal:1

        List<int> agents_index = new List<int>();
        int goal_index = 0;

        string[] temp;

        if (agent.Contains("All"))
        {
            for (int i = 0; i < marathonAgents.Length; i++)
            {
                agents_index.Add(i);
            }
        }
        else
        {
            temp = agent.Split(':');
            int agent_index;
            if (int.TryParse(temp[1], out agent_index) && agent_index <= marathonAgents.Length)
                agents_index.Add(agent_index);
            else
                return;
        }

        temp = goal.Split(':');
        if (!int.TryParse(temp[1], out goal_index))
            return;

        for (int i = 0; i < agents_index.Count; i++)
        {
            marathonAgents[agents_index[i]].Set_Goal(goal_index);
        }
    }

    //public void ReceiveCallback(System.IAsyncResult ar)
    //{
    //    UdpClient u = ((UdpState)(ar.AsyncState)).udpClient;
    //    IPEndPoint e = ((UdpState)(ar.AsyncState)).remoteEP;

    //    byte[] receiveBytes = u.EndReceive(ar, ref e);
    //    string receiveString = Encoding.ASCII.GetString(receiveBytes);

    //    print($"Received: {receiveString}");

    //    u.BeginReceive(new System.AsyncCallback(ReceiveCallback), (UdpState)(ar.AsyncState)); //한번만 받고 끝나지 않도록
    //}

    //public void asdf()
    //{
    //    var academyParameters =
    //                new MLAgents.CommunicatorObjects.UnityRLInitializationOutput();
    //    academyParameters.Name = gameObject.name;
    //    academyParameters.Version = kApiVersion;
    //    foreach (var brain in brains)
    //    {
    //        var bp = brain.brainParameters;
    //        academyParameters.BrainParameters.Add(
    //            MLAgents.Batcher.BrainParametersConvertor(
    //                bp,
    //                brain.gameObject.name,
    //                (MLAgents.CommunicatorObjects.BrainTypeProto)
    //                brain.brainType));
    //    }

    //    //academyParameters.EnvironmentParameters =
    //    //    new MLAgents.CommunicatorObjects.EnvironmentParametersProto();
    //    //foreach (var key in resetParameters.Keys)
    //    //{
    //    //    academyParameters.EnvironmentParameters.FloatParameters.Add(
    //    //        key, resetParameters[key]
    //    //    );
    //    //}

    //    marathonAcademy.brainBatcher.SendAcademyParameters(academyParameters);
    //}
}

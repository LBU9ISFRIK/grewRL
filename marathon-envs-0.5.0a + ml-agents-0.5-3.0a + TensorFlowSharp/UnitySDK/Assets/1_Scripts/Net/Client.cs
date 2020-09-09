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
                        //else if (sp[i].Contains("StateType"))
                        //    ChangeState(sp[i]);
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

    public void ChangeXML(string str)
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
                    string xmlPath = string.Format("N/pybullet_ant_{0}", leg_count);
                    TextAsset asset = Resources.Load<TextAsset>(xmlPath);
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

    public void ChangeState(string str)
    {
        string[] split = str.Split(':');
        split = split[1].Split(',');

        foreach (var item in split)
        {
            foreach (var agent in marathonAgents)
            {
                agent.collectStateList.Clear();

                if (item.Equals(MarathonAgent.E_STATE.position.ToString()))
                {
                    agent.collectStateList.Add(agent.CollectPosition);
                }
                else if (item.Equals(MarathonAgent.E_STATE.torso_velocity.ToString()))
                {
                }
            }
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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text;
using System.Net;
using System.Net.Sockets;

public class Client : MonoBehaviour
{
    public Terrain terrain;
    public int sizeX;
    public int sizeY;
    public int sizeZ;
    public Vector3 terrainSize;
    public Transform transform;

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


    // Start is called before the first frame update
    void Start()
    {
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


        terrain = GetComponent<Terrain>();
    }


    // Update is called once per frame
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
                    print(Encoding.Default.GetString(data));
                    string str = Encoding.Default.GetString(data);

                    string[] sp = str.Split('$');


                    Vector3 temp = transform.localScale;

                    for (int i = 0; i < sp.Length; i++)
                    {


                        print(sp[0]);
                        print(sp[1]);

                        //Ground W
                        temp.x = int.Parse(sp[0]);
                        //Ground H
                        temp.z = int.Parse(sp[1]);
                        transform.localScale = temp;

                        // tile size X = sp[2]
                        int sizeX = int.Parse(sp[2]);
                        int sizeY = 600;
                        // tile size Y = sp[3]
                        int sizeZ = int.Parse(sp[3]);


                        terrainSize = new Vector3(sizeX, sizeY, sizeZ);
                        terrain.terrainData.size = terrainSize;



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
}

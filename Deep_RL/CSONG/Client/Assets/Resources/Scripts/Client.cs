using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text;
using System.Net;
using System.Net.Sockets;
using UnityEditor;
using System.IO;
using Dummiesman;

public class Client : MonoBehaviour
{
    public Terrain terrain;
    public int sizeX;
    public int sizeY;
    public int sizeZ;
    public Vector3 terrainSize;
    public List<GameObject> newObject;
    int number_of_obstackles;
    GameObject modelRootGo;
    float e1_pos_x, e1_pos_y, e1_pos_z, e1_vel_x, e1_vel_y, e1_vel_z;
    float e2_pos_x, e2_pos_y, e2_pos_z, e2_vel_x, e2_vel_y, e2_vel_z;
    float e3_pos_x, e3_pos_y, e3_pos_z, e3_vel_x, e3_vel_y, e3_vel_z;

    string objPath = string.Empty;
    string mtlPath = string.Empty;
    string error = string.Empty;

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

    List<GameObject> gameObjects;
    int n;
    int num;

    //GameObject sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
    private void Awake()
    {
        if (!File.Exists(objPath))
        {
            error = "File doesn't exist.";
        }
        else
        {
            gameObjects = new List<GameObject>();

            if (modelRootGo != null)
                Destroy(modelRootGo);

            for (int i = 1; i <= n; i++)
            {
                //GameObject sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
                //modelRootGo = (GameObject)AssetDatabase.LoadMainAssetAtPath("Assets/Resources/Models/Wolf.fbx");
                //GameObject instanceRoot = Instantiate(modelRootGo);
                modelRootGo = new OBJLoader().Load(objPath, mtlPath);
                modelRootGo.AddComponent<BoxCollider>();
                modelRootGo.AddComponent<Rigidbody>();
                modelRootGo.name = "Obstacle_" + i;
                gameObjects.Add(modelRootGo);


                if (i == 1)
                {
                    gameObjects[0].transform.position = new Vector3(e1_pos_x, e1_pos_y, e1_pos_z);
                    gameObjects[0].GetComponent<Rigidbody>().velocity = new Vector3(e1_vel_x, e1_vel_y, e1_vel_z);
                }

                if (i == 2)
                {

                    gameObjects[1].transform.position = new Vector3(e2_pos_x, e2_pos_y, e2_pos_z);
                    gameObjects[1].GetComponent<Rigidbody>().velocity = new Vector3(e2_vel_x, e2_vel_y, e2_vel_z);
                }

                if (i == 3)
                {

                    gameObjects[2].transform.position = new Vector3(e3_pos_x, e3_pos_y, e3_pos_z);
                    gameObjects[2].GetComponent<Rigidbody>().velocity = new Vector3(e3_vel_x, e3_vel_y, e3_vel_z);
                }
                if (i == 4)
                {

                    gameObjects[3].transform.position = new Vector3(6f, 2f, 6f);
                }
                if (i == 5)
                {

                    gameObjects[4].transform.position = new Vector3(8f, 2f, 2f);
                }

            }
        }

    }

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

                    List<string> result = new List<string>(str.Split('$'));

                    
                    Vector3 temp = terrain.transform.localScale;

                    //Ground W
                    temp.x = int.Parse(result[0]);
                    //Ground H
                    temp.z = int.Parse(result[1]);
                    terrain.transform.localScale = temp;

                    // tile size X = result[2]
                    int sizeX = int.Parse(result[2]);
                    int sizeY = 600;
                    // tile size Y = result[3]
                    int sizeZ = int.Parse(result[3]);
                    terrainSize = new Vector3(sizeX, sizeY, sizeZ);
                    terrain.terrainData.size = terrainSize;

                    num = int.Parse(result[4]);   // number of entity

                    string FolderOfEntity = result[5];  // location of input entity
                    objPath = result[5];
                    // entity_1 pos(x,y,z) and vel(x,y,z)
                    e1_pos_x = float.Parse(result[6]);  
                    e1_pos_y = float.Parse(result[7]);
                    e1_pos_z = float.Parse(result[8]);
                    e1_vel_x = float.Parse(result[9]);
                    e1_vel_y = float.Parse(result[10]);
                    e1_vel_z = float.Parse(result[11]);

                    // entity_2 pos(x,y,z) and vel(x,y,z)
                    e2_pos_x = float.Parse(result[12]);
                    e2_pos_y = float.Parse(result[13]);
                    e2_pos_z = float.Parse(result[14]);
                    e2_vel_x = float.Parse(result[15]);
                    e2_vel_y = float.Parse(result[16]);
                    e2_vel_z = float.Parse(result[17]);

                    // entity_3 pos(x,y,z) and vel(x,y,z)
                    e3_pos_x = float.Parse(result[18]);
                    e3_pos_y = float.Parse(result[19]);
                    e3_pos_z = float.Parse(result[20]);
                    e3_vel_x = float.Parse(result[21]);
                    e3_vel_y = float.Parse(result[22]);
                    e3_vel_z = float.Parse(result[23]);

                    for (int i = 0; i < n; i++)
                    {
                        Destroy(gameObjects[i]);
                    }
                    n = num;
                    Awake();              


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
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text;
using System.Net;
using System.Net.Sockets;
using UnityEditor;
using System.IO;
using System;

namespace ModelLoader
{
    namespace Samples
    {
        public class Client : MonoBehaviour
        {
            public Terrain terrain;
            public int sizeX;
            public int sizeY;
            public int sizeZ;
            public Vector3 terrainSize;
            public List<GameObject> newObject;
        
            GameObject modelRootGo;

            List<string> str_pos_x = new List<string>();
            List<string> str_pos_y = new List<string>();
            List<string> str_pos_z = new List<string>();
            List<string> str_vel_x = new List<string>();
            List<string> str_vel_y = new List<string>();
            List<string> str_vel_z = new List<string>();

            string objPath = string.Empty;
            string mtlPath = string.Empty;
            string error = string.Empty;
            public bool version_error = false;
            public string goal;
            public string reward;
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
            public void Entity()
            {
                if (!File.Exists(objPath))
                {
                    error = "File doesn't exist.";
                }
                else
                {
                    gameObjects = new List<GameObject>();

                    /*if (modelRootGo != null)
                        Destroy(modelRootGo);*/

                    for (int j = 0; j < n; j++)
                    {
                        

                        try
                        {
                            using (var assetLoader = new AssetLoader())
                            {

                                
                                var fileData = File.ReadAllBytes(objPath);
                                modelRootGo = assetLoader.LoadFromMemory(fileData, objPath);
                                modelRootGo.AddComponent<BoxCollider>();
                                modelRootGo.AddComponent<Rigidbody>();
                                modelRootGo.name = "Obstacle_" + (j + 1).ToString();
                                gameObjects.Add(modelRootGo);

                                gameObjects[j].transform.position = new Vector3(float.Parse(str_pos_x[j]), float.Parse(str_pos_y[j]), float.Parse(str_pos_z[j]));
                                gameObjects[j].GetComponent<Rigidbody>().velocity = new Vector3(float.Parse(str_vel_x[j]), float.Parse(str_vel_y[j]), float.Parse(str_vel_z[j]));



                            }
                        }
                        catch (Exception e)
                        {
                            Debug.LogFormat("Unable to load model The loader returned: {0}", e);                            
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
                            //print(num);
                            string FolderOfEntity = result[5];  // location of input entity
                            objPath = result[5];


                            for (int i = 1; i <= num; i++)
                            {
                                str_pos_x.Add(result[5 + i]);
                                str_pos_y.Add(result[5 + num + i]);
                                str_pos_z.Add(result[5+ num * 2 + i]);
                                str_vel_x.Add(result[5+ num * 3 + i]);
                                str_vel_y.Add(result[5+ num * 4 + i]);
                                str_vel_z.Add(result[5+ num * 5 + i]);
                            }

                            foreach (var item in str_pos_x)
                            {
                                print("Pos x = "+item);
                            }
                            foreach (var item in str_pos_y)
                            {
                                print("Pos y = " + item);
                            }
                            foreach (var item in str_pos_z)
                            {
                                print("Pos z = " + item);
                            }

                            foreach (var item in str_vel_x)
                            {
                                print("Vel x = " + item);
                            }
                            foreach (var item in str_vel_y)
                            {
                                print("Vel y = " + item);
                            }
                            foreach (var item in str_vel_z)
                            {
                                print("Vel z = " + item);
                            }


                            for (int i = 0; i < n; i++)
                            {
                                Destroy(gameObjects[i]);

                            }                          

                            n = num;
                            Entity();
                            string key_num_of_goal = result[5 + num * 6 + 1];

                            goal = result[5 + num * 6 + 2];

                            string key_num_of_reward = result[5 + num * 6 + 3];

                            reward = result[5 + num * 6 + 4];

                            print("Goal = "+goal);
                            print("Reward = " + reward);


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
    }
}
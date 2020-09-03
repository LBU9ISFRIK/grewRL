using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text;
using System.Net;
using System.Net.Sockets;

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

    void Start()
    {
        udpClient = new UdpClient();
        remoteEP = new IPEndPoint(IPAddress.Parse(strIP), port);

        udpState.udpClient = udpClient;
        udpState.remoteEP = remoteEP;

        udpClient.Client.Bind(remoteEP);

        udpClient.BeginReceive(new System.AsyncCallback(ReceiveCallback), udpState); //한번만 받음(비동기)
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

    public static void ReceiveCallback(System.IAsyncResult ar)
    {
        UdpClient u = ((UdpState)(ar.AsyncState)).udpClient;
        IPEndPoint e = ((UdpState)(ar.AsyncState)).remoteEP;

        byte[] receiveBytes = u.EndReceive(ar, ref e);
        string receiveString = Encoding.ASCII.GetString(receiveBytes);

        print($"Received: {receiveString}");

        u.BeginReceive(new System.AsyncCallback(ReceiveCallback), (UdpState)(ar.AsyncState)); //한번만 받고 끝나지 않도록
    }
}

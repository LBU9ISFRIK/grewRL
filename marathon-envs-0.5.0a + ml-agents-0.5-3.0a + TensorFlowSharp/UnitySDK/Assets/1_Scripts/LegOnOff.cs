using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MLAgents;

public class LegOnOff : MonoBehaviour {

    public MarathonSpawner[] agents;

    public void Leg(string str)
    {
        string[] split = str.Split(' ');
        for (int i = 0; i < agents.Length; i++)
        {
            if (!agents[i].gameObject.activeSelf)
                continue;

            for (int j = 0; j < agents[i].transform.childCount; j++)
            {
                Transform trans = agents[i].transform.GetChild(j);
                if(trans.name.Contains(split[0]) && trans.name.Contains(split[1]))
                {
                    trans.gameObject.SetActive(!trans.gameObject.activeSelf);
                    //trans.gameObject.SetActive(false);
                }
            } 
        }
    }
}

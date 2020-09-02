//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class SelectLegCount : MonoBehaviour {

//    static SelectLegCount instance = null;
//    static public SelectLegCount Instance
//    {
//        get
//        {
//            return instance;
//        }
//    }

//    void Awake()
//    {
//        if (instance)
//        {
//            DestroyImmediate(gameObject);
//            return;
//        }

//        instance = this;
//        DontDestroyOnLoad(gameObject);
//    }

//    public int legCount;
//    public void SetLegCount(int count)
//    {
//        legCount = count;

//        UnityEngine.SceneManagement.SceneManager.LoadScene(1);
//    }

//    public void EndPlay()
//    {
//        UnityEditor.EditorApplication.isPlaying = false;
//    }
//}

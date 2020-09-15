using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System;

public class TestScript : MonoBehaviour
{

    private void Start()
    {
        var modelRootGo = (GameObject)AssetDatabase.LoadMainAssetAtPath("Assets/Resources/Models/Wolf.fbx");
       
        var instanceRoot = Instantiate(modelRootGo);        
        var variantRoot = PrefabUtility.SaveAsPrefabAsset(instanceRoot, "Assets/Resources/PreFabs/Wolf.prefab");
      
        /*variantRoot.AddComponent<Rigidbody>();
        variantRoot.AddComponent<BoxCollider>();*/
    }

  /*  [MenuItem("Assets/Resources/PreFabs/wolf.prefab")]
    static void ImportExample()
    {
        AssetDatabase.ImportAsset("RAssets/Resources/Wolf.fbx", ImportAssetOptions.Default);

        Debug.Log("Working");
    }*/
}

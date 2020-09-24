using UnityEngine;
using System;
using System.IO;
using System.Linq;

namespace ModelLoader
{
    namespace Samples
    {
        public class LoadingModels : MonoBehaviour
        {

            protected void Awake()
            {
                GameObject myGameObject;
                try
                {
                    using (var assetLoader = new AssetLoader())
                    {

                        var filename = "C:/Users/sabr/Downloads/47-obj/obj/Handgun_obj.obj";
                        //var filename = "C:/Users/sabr/Downloads/75-3ds/3ds/Handgun_3ds.3ds";
                        //var filename = "C:/Unity/Unity_learning/59-stl/stl/Wolf_One_stl.stl";
                        //var filename = "C:/Unity/Unity_learning/75-fbx/fbx/Handgun_fbx_2.fbx";
                        var fileData = File.ReadAllBytes(filename);
                        myGameObject = assetLoader.LoadFromMemory(fileData, filename);

                        //myGameObject.AddComponent<BoxCollider>();
                    }
                }
                catch (Exception e)
                {
                    Debug.LogFormat("Unable to load model The loader returned: {0}", e);
                }
            }

        }
    }
}
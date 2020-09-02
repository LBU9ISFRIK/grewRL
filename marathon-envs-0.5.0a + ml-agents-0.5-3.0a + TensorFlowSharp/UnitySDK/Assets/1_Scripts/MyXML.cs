//using System.Xml;
//using UnityEngine;
//using System.IO;

//public class MyXML: MonoBehaviour
//{
//    // Resources/XML/TestItem.XML 파일.
//    string xmlFileName = "hopper";

//    void Start()
//    {
//        LoadXML(xmlFileName);
//    }

//    private void LoadXML(string _fileName)
//    {
//        string filePath = Application.streamingAssetsPath + "/Models/mujoco_xml/assets/"+ _fileName + ".xml";
//        string[] xml_data = File.ReadAllLines(filePath);

//        for (int i = 0; i < xml_data.Length; i++)
//        {
//            if (xml_data[i].Contains("torso_geom"))
//            {
//                xml_data[i] = xml_data[i].Replace("size=\"0.05\"", "size=\"0.10\"");
//                break;
//            }
//        }

//        string newfilePath = Application.streamingAssetsPath + "/Models/mujoco_xml/assets/" + _fileName + "2.xml";
//        File.WriteAllLines(newfilePath, xml_data);
        

//        MJImport mJImport = new MJImport();
//        mJImport.modelFile = filePath;
//        mJImport.RunImport();

//        MJImport mJImport2 = new MJImport();
//        mJImport2.modelFile = newfilePath;
//        mJImport2.RunImport();
//    }
//}
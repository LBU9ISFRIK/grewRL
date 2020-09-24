using UnityEditor;
using UnityEngine;
using System.IO;
using ModelLoader;

namespace ModelLoaderEditor
{
    public class ModelLoaderAssetPostProcessor : AssetPostprocessor
    {
        private static readonly string[] UnityExtensions = { ".fbx", ".dae", ".3ds", ".dxf", ".obj", ".skp", ".ma", ".mb", ".max", ".c4d", ".blend", ".bmp", ".xml", ".raw" };

        public static void OnPostprocessAllAssets(string[] importedAssets, string[] deletedAssets, string[] movedAssets,
            string[] movedFromAssetPaths)
        {
            if (!ModelLoaderCheckPlugins.PluginsLoaded)
            {
                return;
            }
            foreach (var str in importedAssets)
            {
                CheckForAssimpAsset(str);
            }
            foreach (var str in movedAssets)
            {
                CheckForAssimpAsset(str);
            }
        }

        private static void CheckForAssimpAsset(string str)
        {
            if (!ModelLoaderCheckPlugins.PluginsLoaded)
            {
                return;
            }
            var extension = Path.GetExtension(str);
            if (extension == null)
            {
                return;
            }
            foreach (var unityExtension in UnityExtensions)
            {
                if (unityExtension == extension.ToLower())
                {
                    return;
                }
            }
            if (AssimpInterop.ai_IsExtensionSupported(extension))
            {
                ModelLoaderAssetImporter.Import(str);
                #if ModelLoader_OUTPUT_MESSAGES
                Debug.Log("Asset imported: " + str);
                #endif
            }
        }
    }
}
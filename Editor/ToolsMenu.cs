using UnityEditor;
using static UnityEditor.AssetDatabase;

namespace aiola
{
    public static class ToolsMenu
    {
        [MenuItem("Tools/Setup/Create Default Folders")]
        public static void CreateDefaultFolders()
        {
            Folders.CreateDirectories("_Projet", "Art", "Scripts", "Resources", "Sprites", "Models", "Scenes");
            Refresh();
        }

    
        [MenuItem("Tools/Setup/Load New Manifest")]
        static async void LoadNewManifest()
        {
            await Packages.ReplacePackageFromGist("65874e60149e2b48a029d494a8dc0af5");
        }

        [MenuItem("Tools/Setup/Package/New Input System")]
        static void AddNewInputSystem()
        {
            Packages.InstallUnityPackage("inputsystem");
        }
        
        [MenuItem("Tools/Setup/Package/Post Processing")]
        static void AddPostProcessing()
        {
            Packages.InstallUnityPackage("postprocessing");
        }
        
        [MenuItem("Tools/Setup/Package/Cinemachine")]
        static void AddCinemachine()
        {
            Packages.InstallUnityPackage("cinemachine");
        }
    }
}

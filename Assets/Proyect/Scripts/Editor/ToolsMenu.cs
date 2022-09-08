using UnityEditor;
using static UnityEditor.AssetDatabase;
using static UnityEngine.Application;
using static System.IO.Path;
using static System.IO.Directory;


namespace Game
{
   namespace Editor
    {
        public static class ToolsMenu
        {
            [MenuItem("Tools/Setup/Create Default Folders(2D)")]

            public static void CreateDefeaultFolders2D()
            {
                Dir("Proyect","Scripts","Animations","Arts","Fonts","Prefabs","Scenes","Sounds & Musics","Tests","Tiles");
                Refresh();
            }
            public static void Dir(string root,params string [] dir)
            {
                var fullPath = Combine(dataPath,root);
                foreach (var newDirectory in dir)
                {
                    CreateDirectory(Combine(fullPath,newDirectory));
                }
            }
        }
    }
}

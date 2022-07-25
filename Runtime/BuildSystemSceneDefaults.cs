using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;

namespace SteveJstone
{
    [CreateAssetMenu(menuName ="SteveJstone/Build System Scene Defaults")]
    public class BuildSystemSceneDefaults : ScriptableObject
    {
        [AssetsOnly]
        [SerializeField] private GameObject _buildSystem;
        [AssetsOnly]
        [SerializeField] private GameObject _buildMenu;
        [AssetsOnly]
        [SerializeField] private GameObject _buildGrid;

        private static BuildSystemSceneDefaults _config;

        [MenuItem("GameObject/SteveJstone/Add Build System Scene Defaults")]
        public static void Setup()
        {
            FetchConfig();

            PrefabUtility.InstantiatePrefab(_config._buildSystem);
            PrefabUtility.InstantiatePrefab(_config._buildMenu);
            PrefabUtility.InstantiatePrefab(_config._buildGrid);
        }

        private static void FetchConfig()
        {
            while (true)
            {
                if (_config != null) return;

                var path = GetConfigPath();

                if (path == null)
                {
                    AssetDatabase.CreateAsset(CreateInstance<BuildSystemSceneDefaults>(), $"Assets/{nameof(SceneDefaults)}.asset");
                    Debug.Log($"{nameof(BuildSystemSceneDefaults)}: A config file has been created at the root of your project.<b> You can move this anywhere you'd like.</b>");
                    continue;
                }

                _config = AssetDatabase.LoadAssetAtPath<BuildSystemSceneDefaults>(path);

                break;
            }
        }

        private static string GetConfigPath()
        {
            var paths = AssetDatabase.FindAssets(nameof(BuildSystemSceneDefaults)).Select(AssetDatabase.GUIDToAssetPath).Where(c => c.EndsWith(".asset")).ToList();
            if (paths.Count > 1) Debug.LogWarning($"{nameof(BuildSystemSceneDefaults)}: Multiple assets found. Using the first one.");
            return paths.FirstOrDefault();
        }
    }
}

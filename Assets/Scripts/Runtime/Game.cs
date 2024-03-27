using System;
using Assets;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Runtime
{
    public static class Game
    {
        private static Runtime s_Runtime;
        private static AssetRoot s_AssetRoot;
        private static LocationAsset s_CurrentLocation;

        private static Runner s_Runner;

        public static Runtime Runtime  => s_Runtime;
        public static AssetRoot AssetRoot => s_AssetRoot;
        public static LocationAsset CurrentLocation => s_CurrentLocation;
    
        public static void SetAssetRoot(AssetRoot assetRoot)
        {
            s_AssetRoot = assetRoot;
        }

        public static void InitCurrentLocation(LocationAsset locationAsset)
        {
            s_CurrentLocation = locationAsset;
            AsyncOperation operation = SceneManager.LoadSceneAsync(locationAsset.SceneAsset.name);
            operation.completed += StartRuntime;
        }

        private static void StartRuntime(AsyncOperation operation)
        {
            if (!operation.isDone) 
            {
                throw new Exception("Can't load Scene");
            }
            s_Runtime = new Runtime();
            s_Runner = UnityEngine.Object.FindObjectOfType<Runner>();
            s_Runner.StartRunning();
        }

        public static void StopRuntime()
        {
            s_Runner.StopRunning();
        }

    
    }
}
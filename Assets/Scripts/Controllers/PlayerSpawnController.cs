using UnityEngine;
using Player;
using Assets;

namespace Runtime
{
    public class PlayerSpawnController : IController
    {
        private PlayerSpawnerAsset m_PlayerSpawnerAsset;

        public PlayerSpawnController(PlayerSpawnerAsset PlayerSpawnerAsset)
        {
            m_PlayerSpawnerAsset = PlayerSpawnerAsset;
        }

        public void OnStart() 
        {
            SpawnPlayer(m_PlayerSpawnerAsset.PlayerAsset);
        }

        public void OnStop() 
        {
            // Debug.Log("OnStop was called");
        }

        public void OnTick () 
        {
            // Debug.Log("OnTick was called");
        }

        private void SpawnPlayer(PlayerAsset asset)
        {
            PlayerView view = Object.Instantiate(asset.ViewPrefab);
            view.transform.position = Vector3.zero;
            PlayerData data = new PlayerData(asset);

            data.AttachView(view);

            Game.Runtime.PlayerSpawned(data, view);
        }
    }
    
}
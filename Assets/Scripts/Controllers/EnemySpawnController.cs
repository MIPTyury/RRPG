using UnityEngine;
using Enemy;
using System.Collections.Generic;
using Assets;

namespace Runtime
{
    public class EnemySpawnController : IController
    {
        private List<EnemyTypeAsset> m_EnemyTypeAsset;

        public EnemySpawnController(List<EnemyTypeAsset> EnemyTypeAsset)
        {
            m_EnemyTypeAsset = EnemyTypeAsset;
        }

        public void OnStart() 
        {
            foreach (EnemyTypeAsset enemyType in m_EnemyTypeAsset) 
            {
                SpawnEnemy(enemyType.EnemyType);
            }
        }

        public void OnStop() 
        {
            // Debug.Log("OnStop was called");
        }

        public void OnTick () 
        {
            // Debug.Log("OnTick was called");
        }

        private void SpawnEnemy(EnemyAsset asset)
        {
            EnemyView view = Object.Instantiate(asset.ViewPrefab);
            view.transform.position = asset.Position;
            EnemyData data = new(asset);

            data.AttachView(view);

            Game.Runtime.EnemySpawned(data, view);
        }
    }
    
}
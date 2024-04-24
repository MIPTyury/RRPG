using Assets;
using Item;
using Player;
using Enemy;
using UnityEngine;

namespace Runtime
{
    public class InitRuntimeController : IController
    {   
        private LocationAsset m_LocationAsset;

        public InitRuntimeController (LocationAsset locationAsset)
        {
            m_LocationAsset = locationAsset;

            SpawnPlayer();
            SpawnAllEnemies();
            Game.Runtime.InitPotions(m_LocationAsset.PlayerAsset);
            SpawnAllPotions();
        }
        public void OnStart() 
        {
            SpawnAllEnemies();
        }

        public void OnStop() 
        {
            
        }

        public void OnTick () 
        {

        }

        private void SpawnPlayer()
        {
            PlayerView view = Object.Instantiate(m_LocationAsset.PlayerAsset.ViewPrefab);
            view.transform.position = Vector3.zero;
            PlayerData data = new PlayerData(m_LocationAsset.PlayerAsset);

            data.AttachView(view);

            Game.Runtime.SetPlayer(data, view);
        }

        private void SpawnAllEnemies()
        {
            foreach (EnemyAsset enemyType in m_LocationAsset.EnemyTypes) 
            {
                SpawnEnemy(enemyType);
            }
        }

        private void SpawnEnemy(EnemyAsset asset)
        {
            EnemyView view = Object.Instantiate(asset.ViewPrefab);
            view.transform.position = asset.Position;
            EnemyData data = new(asset);

            data.AttachView(view);

            Game.Runtime.SetEnemies(data, view);
        }

        public void SetWeaponData()
        {   
            WeaponData data = new WeaponData(m_LocationAsset.PlayerAsset.WeaponAsset);

            Game.Runtime.SetWeapon(data);
        }

        public void SpawnAllPotions()
        {
            foreach (PotionAsset item in m_LocationAsset.Potions)
            {
                SpawnPotion(item);
            }
        }
        public void SpawnPotion(PotionAsset asset)
        {
            PotionView view = Object.Instantiate(asset.PotionView);
            view.transform.position = asset.Position;
            PotionData data = new(asset);

            data.AttachView(view);
        }
    }
}
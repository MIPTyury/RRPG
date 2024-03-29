using Assets;
using UnityEngine;

namespace Runtime
{
    public class PlayerDamageController : IController
    {   
        private PlayerSpawnerAsset m_PlayerSpawnerAsset;
        private EnemyTypeAsset m_enemyTypeAsset;

        private Animator m_Animator;

        public PlayerDamageController (PlayerSpawnerAsset PlayerSpawnerAsset)
        {
            m_PlayerSpawnerAsset = PlayerSpawnerAsset;
        }
        public void OnStart() 
        {
            m_Animator = Game.Runtime.PlayerView.GetComponent<Animator>();
        }

        public void OnStop() 
        {
            // Debug.Log("OnStop was called");
        }

        public void OnTick () 
        {
            Damage(m_PlayerSpawnerAsset.PlayerAsset);
        }

        private void Damage(PlayerAsset asset)
        {   
            if (Input.GetKeyDown(KeyCode.Mouse0)) 
            {   
                if (Game.Runtime.EnemyDatas[0].currentHealth > 0) 
                {
                    Debug.Log($"{Game.Runtime.EnemyDatas[0].currentHealth}");
                    Game.Runtime.EnemyDatas[0].currentHealth -= asset.weaponAsset.damage;
                    Game.Runtime.EnemyViews[0].AttachData(Game.Runtime.EnemyDatas[0]);
                }
                else
                {
                    Debug.Log("Enemy Died");
                }
            }
        }
    }  
}
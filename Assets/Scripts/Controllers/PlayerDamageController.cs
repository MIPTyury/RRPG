using Assets;
using UnityEngine;
using Managers;
using Enemy;
using UnityEditor.VersionControl;

namespace Runtime
{
    public class PlayerGiveDamageController : IController
    {   
        private PlayerSpawnerAsset m_PlayerSpawnerAsset;
        private EnemyTypeAsset m_enemyTypeAsset;

        private Animator m_Animator;

        public PlayerGiveDamageController (PlayerSpawnerAsset PlayerSpawnerAsset)
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
            GiveDamage();
        }
        private void GiveDamage()
        {   
            if (Input.GetKeyDown(KeyCode.Mouse0)) 
            {
                GetTarget();
                DeathEventManager.SendEnemyDied();
            }
        }

        private void GetTarget()
        {
            Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(Game.Runtime.PlayerView.transform.Find("AttackPoint").transform.position, Game.Runtime.PlayerData.Weapon.AttackRange, LayerMask.GetMask("Enemies"));
            
            foreach (Collider2D enemy in hitEnemies)
            {
                if (enemy.TryGetComponent(out Enemy.EnemyView view))
                {
                    if (Game.Runtime.Enemies.TryGetValue(view, out EnemyData enemyData))
                    {
                        enemyData.currentHealth -= m_PlayerSpawnerAsset.PlayerAsset.WeaponAsset.damage;
                    }
                }
            } 
        }
    }
}
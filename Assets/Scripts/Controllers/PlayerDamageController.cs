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
            }
        }


        private void GetTarget()
        {
            Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(Game.Runtime.PlayerView.transform.Find("AttackPoint").transform.position, Game.Runtime.PlayerData.Weapon.AttackRange, LayerMask.GetMask("Enemies"));
            foreach (Collider2D enemy in hitEnemies)
            {
                EnemyView view = enemy.gameObject.GetComponent<EnemyView>();
                EnemyData data = Game.Runtime.Enemies[view];
                
                data.currentHealth -= m_PlayerSpawnerAsset.PlayerAsset.WeaponAsset.damage;
                Debug.Log($"{view.gameObject.name} - {data.currentHealth}");
            }

            DeathEventManager.SendEnemyDied();
        }
    }
}
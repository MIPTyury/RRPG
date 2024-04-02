using Assets;
using UnityEngine;
using Managers;
using Enemy;
using System.Collections.Generic;
using UnityEngine.UIElements;

namespace Runtime
{
    public class PlayerMeleeDamageController : IController
    {   
        private PlayerSpawnerAsset m_PlayerSpawnerAsset;
        private EnemyTypeAsset m_enemyTypeAsset;

        private Animator m_Animator;

        public PlayerMeleeDamageController (PlayerSpawnerAsset PlayerSpawnerAsset)
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
            List<Collider2D> hitEnemies = new List<Collider2D>(Physics2D.OverlapCircleAll(Game.Runtime.PlayerView.transform.Find("AttackPoint").transform.position, Game.Runtime.PlayerData.Weapon.AttackRange, LayerMask.GetMask("Enemies")));
            
            List<GameObject> enemies = GetUnique(hitEnemies);

            foreach (GameObject enemy in enemies)
            {
                EnemyView view = enemy.GetComponent<EnemyView>();
                EnemyData data = Game.Runtime.Enemies[view];
                
                data.currentHealth -= m_PlayerSpawnerAsset.PlayerAsset.WeaponAsset.damage;
                Debug.Log($"{view.gameObject.name} - {data.currentHealth}");
            }

            DeathEventManager.SendEnemyDied();
        }

        private List<GameObject> GetUnique(List<Collider2D> list)
        {
            HashSet<GameObject> uniqueObjects = new HashSet<GameObject>();

            foreach (Collider2D collider in list)
            {
                uniqueObjects.Add(collider.gameObject);
            }

            return new List<GameObject>(uniqueObjects);
        }



    }
}
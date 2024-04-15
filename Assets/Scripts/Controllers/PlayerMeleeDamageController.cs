using UnityEngine;
using Managers;
using Enemy;
using System.Collections.Generic;
using Utility;

namespace Runtime
{
    public class PlayerMeleeDamageController : IController
    {   

        private Animator m_Animator;

        public PlayerMeleeDamageController ()
        {

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
            if (Input.GetKeyDown(Controlls.AttackKey)) 
            {
                GetTarget();
            }
        }

        private void GetTarget()
        {
            List<Collider2D> hitEnemies = new List<Collider2D>(Physics2D.OverlapCircleAll(Game.Runtime.PlayerView.transform.Find("AttackPoint").transform.position, Game.Runtime.PlayerData.Weapon.AttackRange, LayerMask.GetMask("Enemies")));
            
            List<GameObject> enemies = GetUnique(hitEnemies);

            foreach (var enemy in enemies)
            {
                EnemyView view = enemy.GetComponent<EnemyView>();
                EnemyData data = Game.Runtime.Enemies[view];
                
                data.currentHealth -= Game.Runtime.PlayerData.Weapon.weakDamage;
                view.AttachData(data);
            }

            DeathEventManager.SendEnemyDied();
        }

        private List<GameObject> GetUnique(List<Collider2D> list)
        {
            HashSet<GameObject> uniqueObjects = new HashSet<GameObject>();

            foreach (var collider in list)
            {
                uniqueObjects.Add(collider.gameObject);
            }

            return new List<GameObject>(uniqueObjects);
        }



    }
}
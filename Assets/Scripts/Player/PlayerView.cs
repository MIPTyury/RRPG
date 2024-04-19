using UnityEngine;
using Managers;
using System.Collections.Generic;
using Item;

namespace Player
{
    public class PlayerView : MonoBehaviour
    {
        private PlayerData m_PlayerData;

        public PlayerData PlayerData => m_PlayerData;

        public List<PotionView> Potions;
        public List<PotionView> Throwers;

        public void Awake()
        {
            DeathEventManager.OnEnemyDied.AddListener(Died);
        }

        public void AttachData(PlayerData data) 
        {
            m_PlayerData = data;
        }

        public void Died()
        {
            if (m_PlayerData.currentHealth <= 0)
            {
                Destroy(gameObject);
            }
        }

        public void SetPotionView(List<PotionView> view)
        {
            Potions = view;
        }
        
        void OnDrawGizmosSelected()
        {
            Gizmos.DrawWireSphere(transform.Find("AttackPoint").transform.position, m_PlayerData.Weapon.AttackRange);
        }
    }
}
using UnityEngine;
using Managers;
using UnityEngine.SceneManagement;

namespace Player
{
    public class PlayerView : MonoBehaviour
    {
        private PlayerData m_PlayerData;

        public PlayerData PlayerData => m_PlayerData;

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
        
        void OnDrawGizmosSelected()
        {
            Gizmos.DrawWireSphere(transform.Find("AttackPoint").transform.position, m_PlayerData.Weapon.AttackRange);
        }
    }
}
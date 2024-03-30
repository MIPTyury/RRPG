using UnityEngine;

namespace Player
{
    public class PlayerView : MonoBehaviour
    {
        private PlayerData m_PlayerData;

        public PlayerData PlayerData => m_PlayerData;

        public void AttachData(PlayerData data) 
        {
            m_PlayerData = data;
        }
        
        void OnDrawGizmosSelected()
        {
            Gizmos.DrawWireSphere(transform.Find("AttackPoint").transform.position, m_PlayerData.Weapon.AttackRange);
        }
    }
}
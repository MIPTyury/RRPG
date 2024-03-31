using UnityEngine;
using Managers;

namespace Enemy
{
    public class EnemyView : MonoBehaviour
    {
        private EnemyData m_EnemyData;

        public EnemyData EnemyData => m_EnemyData;

        public void Awake()
        {
            DeathEventManager.OnEnemyDied.AddListener(Died);
        }

        public void AttachData(EnemyData data)
        {
            m_EnemyData = data;
        }

        public void Died()
        {
            if (m_EnemyData.currentHealth <= 0)
            {
                Destroy(gameObject);
            }
        }
    }
}
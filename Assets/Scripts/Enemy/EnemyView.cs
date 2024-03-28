using UnityEngine;

namespace Enemy
{
    public class EnemyView : MonoBehaviour
    {
        private EnemyData m_EnemyData;

        public EnemyData EnemyData => m_EnemyData;

        public void AttachData(EnemyData data)
        {
            m_EnemyData = data;
        }
    }
}
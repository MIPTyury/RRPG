using Assets;

namespace Enemy
{
    public class EnemyData
    {
        private EnemyView m_EnemyView;

        public EnemyView EnemyView => m_EnemyView;

        public float maxHealth;
        public float currentHealth;
        
        public EnemyData(EnemyAsset asset)
        {
            maxHealth = asset.maxHealth;
            currentHealth = maxHealth;

            m_EnemyView = asset.ViewPrefab;
        }

        public void AttachView(EnemyView view)
        {
            m_EnemyView = view;
            m_EnemyView.AttachData(this);
        }
    }
}
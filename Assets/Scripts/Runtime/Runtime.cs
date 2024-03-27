using System.Collections.Generic;
using Enemy;
using Player;

namespace Runtime
{
    public class Runtime
    {
        private List<EnemyData> m_EnemyDatas;
        private PlayerData m_PlayerData;

        public IReadOnlyList<EnemyData> EnemyDatas => m_EnemyDatas;
        public PlayerData PlayerData => m_PlayerData;
    }
}
using System.Collections.Generic;
using Enemy;
using Player;

namespace Runtime
{
    public class Runtime
    {
        private List<EnemyData> m_EnemyDatas;
        private PlayerData m_PlayerData;
        private PlayerView m_PlayerView;

        public PlayerData PlayerData => m_PlayerData;
        public PlayerView PlayerView => m_PlayerView;
        public IReadOnlyList<EnemyData> EnemyDatas => m_EnemyDatas;

        public void PlayerSpawned(PlayerData data, PlayerView view)
        {
            m_PlayerData = data;
            m_PlayerView = view;
        }
    }
}
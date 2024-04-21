using System.Collections.Generic;
using Enemy;
using Player;
using UnityEngine;
using Item;
using Assets;
// using System.Linq;

namespace Runtime
{
    public class Runtime
    {
        private Dictionary<EnemyView, EnemyData> m_Enemies = new Dictionary<EnemyView, EnemyData>();
        private PlayerData m_PlayerData;
        private PlayerView m_PlayerView;

        private List<WeaponData> m_WeaponData = new List<WeaponData>();
        private Transform m_CameraTransform;

        public PlayerData PlayerData => m_PlayerData;
        public PlayerView PlayerView => m_PlayerView;
        public List<WeaponData> WeaponDatas => m_WeaponData;
        public IReadOnlyDictionary<EnemyView, EnemyData> Enemies => m_Enemies;

        public Transform CameraTransform => m_CameraTransform;

        public void SetPlayer(PlayerData data, PlayerView view)
        {
            m_PlayerData = data;
            m_PlayerView = view;
        }

        public void SetEnemies(EnemyData data, EnemyView view)
        {
            m_Enemies[view] = data;
        }

        public void SetWeapon(WeaponData weapon)
        {
            m_WeaponData.Add(weapon);
        }

        public void InitPotions(PlayerAsset asset)
        {
            GetPotionData(asset);
        }

        private void GetPotionData(PlayerAsset asset)
        {   
            List<PotionData> data = new List<PotionData>();

            foreach (PotionAsset element in asset.Potions)
            {
                data.Add(new PotionData(element));
            }

            Game.Runtime.PlayerData.SetPotionData(data);
        }
    }
}
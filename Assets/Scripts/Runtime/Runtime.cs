using System.Collections.Generic;
using Enemy;
using Player;
using UnityEngine;
using Weapons;
using Assets;
using Skills;

namespace Runtime
{
    public class Runtime
    {
        private List<EnemyData> m_EnemyDatas = new List<EnemyData>();
        private List<EnemyView> m_EnemyViews = new List<EnemyView>();

        private Dictionary<EnemyView, EnemyData> m_Enemies = new Dictionary<EnemyView, EnemyData>();
        private List<SkillData> m_Skills = new List<SkillData>();
        private PlayerData m_PlayerData;
        private PlayerView m_PlayerView;

        private List<WeaponData> m_WeaponData;
        private Transform m_CameraTransform;

        public PlayerData PlayerData => m_PlayerData;
        public PlayerView PlayerView => m_PlayerView;
        public List<WeaponData> WeaponDatas => m_WeaponData;
        public IReadOnlyDictionary<EnemyView, EnemyData> Enemies => m_Enemies;
        public List<SkillData> SkillDatas => m_Skills;

        public Transform CameraTransform => m_CameraTransform;

        public void PlayerSpawned(PlayerData data, PlayerView view)
        {
            m_PlayerData = data;
            m_PlayerView = view;
        }

        public void EnemySpawned(EnemyData data, EnemyView view)
        {
            m_Enemies[view] = data;
        }

        public void SetCamera(Transform transform)
        {
            m_CameraTransform = transform;
        }

        public void SetSkills(SkillData skill)
        {
            m_Skills.Add(skill);
        }

        public void SetWeapon(WeaponData weapon)
        {
            m_WeaponData.Add(weapon);
        }
    }
}
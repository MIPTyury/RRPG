using System.Collections.Generic;
using Assets;

namespace Weapons
{
    public class WeaponData
    {   
        private string m_name;
        private string m_description;
        private float m_damage;
        private float m_AttackRange;
        private SkillAsset m_SkillAsset;

        public string Name => m_name;
        
        public string Description => m_description;
        public float damage => m_damage;

        public float AttackRange => m_AttackRange;

        public SkillAsset SkillAsset => m_SkillAsset;

        public WeaponData(WeaponAsset asset) 
        {
            m_name = asset.m_name;
            m_damage = asset.damage;
            m_AttackRange = asset.AttackRange;
            m_SkillAsset = asset.SkillAsset;
        }
    }
}
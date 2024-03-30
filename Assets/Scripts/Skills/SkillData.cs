using Assets;
using Enemy;
using UnityEngine;

namespace Skills
{
    public class SkillData
    {   
        private float m_damage;
        private float m_heal;
        private string m_name;
        private string m_type;

        public float Damage => m_damage;
        public float Heal => m_heal;
        public string Name => m_name;
        public string Type => m_type;

        public SkillData (SkillAsset asset)
        {
            m_damage = asset.damage;
            m_heal = asset.heal;
            m_name = asset.m_name;
            m_type = asset.skillType;
        }
    }
}
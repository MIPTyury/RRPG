using System.Collections.Generic;
using UnityEngine;

namespace Assets
{
    [CreateAssetMenu(menuName = "Asset/Weapon Asset", fileName = "Weapon Asset")]
    public class WeaponAsset : ScriptableObject
    {   
        public string m_name;
        
        [TextArea] public string description;

        public float damage;

        public float AttackRange;

        public SkillAsset SkillAsset;
    }
}
using UnityEngine;
using System.Collections.Generic;
using Skills;
using Enemy;

namespace Assets
{
    [CreateAssetMenu(menuName = "Asset/Skill Asset", fileName = "Skill Asset")]
    public class SkillAsset : ScriptableObject
    {
        public string skillType;
        public EnemyData target;

        public float damage;
        public float heal;

        public SkillView viewPrefab;

    }
}
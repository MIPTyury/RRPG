using UnityEngine;
using Enemy;

namespace Assets
{
    [CreateAssetMenu(menuName = "Asset/Skill Asset", fileName = "Skill Asset")]
    public class SkillAsset : ScriptableObject
    {   
        public string m_name;
        public string skillType;

        public float damage;
        public float heal;

        public Sprite Sprite;

    }
}
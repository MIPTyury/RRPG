using UnityEngine;

namespace Assets
{
    [CreateAssetMenu(menuName = "Asset/Skill Asset", fileName = "Skill Asset")]
    public class SkillAsset : ScriptableObject
    {   
        public string m_name;
        public string skillType;

        [TextArea] public string description;

        public float damage;
        public float heal;

        public Sprite Sprite;

    }
}
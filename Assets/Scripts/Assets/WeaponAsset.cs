using UnityEngine;

namespace Assets
{
    [CreateAssetMenu(menuName = "Asset/Weapon Asset", fileName = "Weapon Asset")]
    public class WeaponAsset : ScriptableObject
    {   
        public string m_name;

        public float damage;

        public float AttackRange;
        
    }
}
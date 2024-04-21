using Item;
using UnityEngine;

namespace Assets
{
    [CreateAssetMenu(menuName = "Asset/Item/Weapon Asset", fileName = "Weapon Asset")]
    public class WeaponAsset : ItemAsset
    {   
        public float AttackRange;
        public WeaponView WeaponView;
    }
}
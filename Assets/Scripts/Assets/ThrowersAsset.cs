using Item;
using UnityEngine;

namespace Assets
{
    [CreateAssetMenu(menuName = "Asset/Item/Thrower Asset", fileName = "Thrower Asset")]
    public class ThrowersAsset : ItemAsset
    {   
        public float AttackRange;
        public ThrowerView WeaponView;
    }
}
using Item;
using UnityEngine;

namespace Assets
{
    [CreateAssetMenu(menuName = "Asset/Item/Potion Asset", fileName = "Potion Asset")]
    public class PotionAsset : ItemAsset
    {   
        public PotionView PotionView;
    }
}
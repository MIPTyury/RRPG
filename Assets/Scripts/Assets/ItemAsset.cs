using UnityEngine;

namespace Assets
{
    [CreateAssetMenu(menuName = "Asset/Item Asset", fileName = "Item Asset")]
    public class ItemAsset : ScriptableObject
    {   
        public ScriptableObject ItemTypeAsset;
        
    }
}
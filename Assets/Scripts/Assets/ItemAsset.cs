using Item;
using UnityEngine;

namespace Assets
{
    [CreateAssetMenu(menuName = "Asset/Item Asset", fileName = "Item Asset")]
    public class ItemAsset : ScriptableObject
    {   
        public string Name;
        public string Type;
        public float Value;
        public float AttackRange;
        [TextArea] public string Description;

        [SerializeField] public IItemView ItemView;
    }
}
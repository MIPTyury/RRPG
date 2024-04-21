using UnityEngine;
using Perk;

namespace Assets
{
    [CreateAssetMenu(menuName = "Asset/Perk Asset", fileName = "Perk Asset")]
    public class PerkAsset : ScriptableObject
    {   
        public string Name;
        public string Type;
        [HideInInspector] public float Stat;
        public float Percent;
        [TextArea] public string Description;

        public PerkView View;
    }
}
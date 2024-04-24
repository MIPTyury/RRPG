using UnityEngine;
using Perk;

namespace Assets
{
    [CreateAssetMenu(menuName = "Asset/Perk Container", fileName = "Perk Container")]
    public class PerkContainerAsset : ScriptableObject
    {   
        public PerkView View1;
        public PerkView View2;
        public PerkView View3;

    }
}
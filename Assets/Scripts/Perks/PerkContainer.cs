using Assets;
using UnityEngine;

namespace Perk
{
    public class PerkContainer : MonoBehaviour
    {   
        public PerkView cell1;
        public PerkView cell2;
        public PerkView cell3;
        
        public PerkContainer(PerkContainerAsset asset)
        {
            cell1 = asset.View1;
            cell2 = asset.View2;
            cell3 = asset.View3;
        }
    }
}
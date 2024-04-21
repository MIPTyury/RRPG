using Assets;
using UnityEngine;

namespace Perk
{
    public class PerkView : MonoBehaviour
    {   
        public PerkData Data;

        public Sprite sprite;
        
        public PerkView(PerkAsset asset)
        {
            
        }

        public void AttachData(PerkData data)
        {
            Data = data;
        }
    }
}
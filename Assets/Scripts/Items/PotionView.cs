using UnityEngine;

namespace Item
{
    public class PotionView : MonoBehaviour, IItemView 
    {
        private PotionData m_PotionData;
        
        public PotionData PotionData => m_PotionData;

        public PotionView (PotionData data)
        {
           m_PotionData = data;
        }

        public void AttachData(PotionData data)
        {
            m_PotionData = data;
        }
    }
}
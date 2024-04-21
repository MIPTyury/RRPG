using UnityEngine;

namespace Item
{
    public class PotionView : BaseItemView
    {
        public PotionData PotionData { get; private set; }

        public PotionView (PotionData data)
        {
           PotionData = data;
        }

        public void AttachData(PotionData data)
        {
            PotionData = data;
        }
    }
}
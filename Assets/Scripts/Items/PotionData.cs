using Assets;

namespace Item
{
    public class PotionData
    {
        private string m_Name;
        private string m_Type;
        private float m_Value;

        public string Name => m_Name;
        public string Type => m_Type;
        public float Value => m_Value;

        public PotionView potionView;

        public PotionData (ItemAsset asset)
        {
            m_Name = asset.Name;
            m_Type = asset.Type;
            m_Value = asset.Value;
        }

        public void AttachView(PotionView view)
        {
            potionView = view;
            potionView.AttachData(this);
        }
    }
}
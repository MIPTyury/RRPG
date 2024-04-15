using Assets;

namespace Item
{
    public class WeaponData : IItemData
    {
        private WeaponView m_WeaponView;
        private string m_Name;
        private string m_Type;
        private float m_Value;
        private float m_AttackRange;
        private string m_description;


        public WeaponView WeaponView => m_WeaponView;
        public string Name => m_Name;
        public string Type => m_Type;
        public float Value => m_Value;
        public float AttackRange => m_AttackRange;
        public string Description => m_description;

        public WeaponData (ItemAsset asset)
        {
            m_Name = asset.Name;
            m_Type = asset.Type;
            m_Value = asset.Value;
            m_AttackRange = asset.AttackRange;
            m_description = asset.Description;
        }

        public void AttachView(WeaponView view)
        {
            m_WeaponView = view;
            view.AttachData(this);
        }
    }
}
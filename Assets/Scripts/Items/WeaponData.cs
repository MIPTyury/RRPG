using Assets;

namespace Item
{
    public class WeaponData : BaseItemData
    {
        public WeaponView WeaponView;
        public float AttackRange;

        public WeaponData (ItemAsset asset)
        {
            Name = asset.Name;
            Value = asset.Value;
            Description = asset.Description;
            // WeaponView = asset.PotionView;

        }

        public void AttachView(WeaponView view)
        {
            WeaponView = view;
            view.AttachData(this);
        }
    }
}
using Assets;

namespace Perk
{
    public class PerkData
    {   
        public string Name;
        public float Stat;
        public float Percent;
        public string Description;

        public PerkView View;
        
        public PerkData(PerkAsset asset) 
        {
            Name = asset.Name;
            Stat = asset.Stat;
            Percent = asset.Percent;
            Description = asset.Description;
            View = asset.View;
        }

        public void AttachView(PerkView view)
        {
            View = view;
            View.AttachData(this);
        }
    }
}
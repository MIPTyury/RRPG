using UnityEngine;

namespace Item
{
    public class WeaponView : MonoBehaviour
    {
        private WeaponData m_WeaponData;
        
        public WeaponData WeaponData => m_WeaponData;

        public WeaponView (WeaponData data)
        {
           m_WeaponData = data;
        }

        public void AttachData(WeaponData data)
        {
            m_WeaponData = data;
        }
    }
}
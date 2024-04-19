using UnityEngine;

namespace Item
{
    public class ThrowerView : MonoBehaviour
    {
        private ThrowerData m_ThrowerData;
        
        public ThrowerData ThrowerData => m_ThrowerData;

        public ThrowerView (ThrowerData data)
        {
           m_ThrowerData = data;
        }

        public void AttachData(ThrowerData data)
        {
            m_ThrowerData = data;
        }
    }
}
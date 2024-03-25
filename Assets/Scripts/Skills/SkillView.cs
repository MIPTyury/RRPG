using UnityEngine;

namespace Skills
{
    public class SkillView
    {   
        private SkillData m_skillData;

        public SkillData skillData => m_skillData;
         public void AttachData(SkillData data) {
            m_skillData = data;
         }
    }
}
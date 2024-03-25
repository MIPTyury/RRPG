using UnityEngine;

namespace Skills
{
    public class SkillData
    {   
        private SkillView m_skillView;

        public SkillView skillView => m_skillView;
         public void AttachView(SkillView view) {
            m_skillView = view;
         }
    }
}
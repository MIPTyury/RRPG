using UnityEngine;
using System.Collections;

public class SkillManager : MonoBehaviour
{
    public Skill[] skills;

    void Update()
    {
        foreach (Skill skill in skills)
        {
            if (Input.GetKeyDown(skill.skillKey))
            {
                skill.Activate();
            }
        }
    }
}

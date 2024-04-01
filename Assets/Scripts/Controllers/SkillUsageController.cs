using UnityEngine;
using Assets;
using System.Collections.Generic;
using System;
using Skills;

namespace Runtime
{
    public class SkillUsageController : IController
    {
        private SkillAsset m_SkillAsset;
        private Dictionary<string, Action> ModeDict = new();

        public SkillUsageController(PlayerSpawnerAsset PlayerSpawnerAsset)
        {
            m_SkillAsset = PlayerSpawnerAsset.PlayerAsset.WeaponAsset.SkillAsset;

            ModeDict["Heal"] = Heal;
            ModeDict["Damage"] = Damage;
            ModeDict["Move"] = Move;
        }

        public void OnStart() 
        {
            
        }

        public void OnStop() 
        {
            // Debug.Log("OnStop was called");
        }

        public void OnTick () 
        {
            UseSkill();
            TakeDamage();
        }

        private void UseSkill()
        {
            ModeDict[m_SkillAsset.skillType].Invoke();

            SkillData data = new SkillData(m_SkillAsset);

            Game.Runtime.SetSkills(data);
        }

        private void Damage ()
        {
            
        }

        private void Heal ()
        {
            if (Input.GetKeyDown(KeyCode.Q)) 
            {
                if (Game.Runtime.PlayerData.currentHealth > Game.Runtime.PlayerData.maxHealth - m_SkillAsset.heal) 
                {
                    Game.Runtime.PlayerData.currentHealth = Game.Runtime.PlayerData.maxHealth;
                    return;
                }

                Game.Runtime.PlayerData.currentHealth += m_SkillAsset.heal;

                Debug.Log($"Добавилось {m_SkillAsset.heal} hp, сейчас {Game.Runtime.PlayerData.currentHealth}/{Game.Runtime.PlayerData.maxHealth} HP");
            }
        }

        private void Move ()
        {
            
        }

        //Для проверки работоспособности, потом убрать!!!
        private void TakeDamage()
        {
            if (Input.GetKeyDown(KeyCode.G)) 
            {
                if (Game.Runtime.PlayerData.currentHealth > 40) 
                {
                    Game.Runtime.PlayerData.currentHealth -= 40;
                    Debug.Log($"Снялось 40 hp, сейчас {Game.Runtime.PlayerData.currentHealth}/{Game.Runtime.PlayerData.maxHealth} HP");
                }
                else
                {
                    Game.Runtime.PlayerData.currentHealth = 0;
                    Debug.Log($"Снялось 40 hp, сейчас {Game.Runtime.PlayerData.currentHealth}/{Game.Runtime.PlayerData.maxHealth} HP");
                }
            }
        }
    }
    
}
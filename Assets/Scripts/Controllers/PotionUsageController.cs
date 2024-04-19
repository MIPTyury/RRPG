using System.Linq;
using Item;
using Unity.VisualScripting;
using UnityEngine;
using Utility;

namespace Runtime
{
    public class PotionUsageController : IController
    { 
        public PotionUsageController ()
        {

        }
        public void OnStart() 
        {

        }

        public void OnStop() 
        {
            
        }

        public void OnTick () 
        {
            if (Input.GetKeyDown(Controlls.UsePotionKey))
            {
                // Debug.Log($"До применения - {Game.Runtime.PlayerData.Potions.Count} зелий");
                UsePotion();
            }

            if (Input.GetKeyDown(Controlls.DebugDamage))
            {
                Game.Runtime.PlayerData.currentHealth -= 10;
                // Debug.Log($"После уменьшения стало - {Game.Runtime.PlayerData.currentHealth}");
            }
        }

        private void UsePotion ()
        {
            if (IsPotionAcessable())
            {
                // Debug.Log($"Было - {Game.Runtime.PlayerData.currentHealth}");
                ExecutePotionEffect();
                // Debug.Log($"Стало - {Game.Runtime.PlayerData.currentHealth}");
            }
        }

        private bool IsPotionAcessable()
        {
            return Game.Runtime.PlayerData.Potions.Count >= 1;
        }

        private void ExecutePotionEffect()
        {
            Heal();
        }

        private void Heal()
        {
            Debug.Log($"Всего зелий {Game.Runtime.PlayerData.Potions.Count}");
            Game.Runtime.PlayerData.currentHealth += Game.Runtime.PlayerData.Potions.Last().Value;
            Game.Runtime.PlayerData.Potions.Remove(Game.Runtime.PlayerData.Potions.Last());

            if (Game.Runtime.PlayerData.currentHealth > Game.Runtime.PlayerData.maxHealth)
            {
                Game.Runtime.PlayerData.currentHealth = Game.Runtime.PlayerData.maxHealth;
            }
        }
        
    }
}
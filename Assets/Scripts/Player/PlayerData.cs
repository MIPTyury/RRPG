using System.Collections.Generic;
using Assets;
using Item;
using Perk;

namespace Player
{
    public class PlayerData
    {   
        private PlayerView m_PlayerView;
        private WeaponAsset m_weapon;
        public PlayerView PlayerView => m_PlayerView;
        public WeaponAsset Weapon => m_weapon;

        public List<PotionData> Potions = new List<PotionData>();
        public List<ThrowerData> Throwers = new List<ThrowerData>();

        public List<PerkData> Perks = new List<PerkData>();

        public float maxHealth;
        public float currentHealth;
        public float maxMana;
        public float currentMana;
        public float maxStamina;
        public float currentStamina;
        public float speed;
        
        public PlayerData(PlayerAsset asset) 
        {
            maxHealth = asset.maxHealth;
            currentHealth = maxHealth;
            maxMana = asset.maxMana;
            currentMana = maxMana;
            maxStamina = asset.maxStamina;
            currentStamina = maxStamina;
            speed = asset.speed;
            m_weapon = asset.WeaponAsset;
            m_PlayerView = asset.ViewPrefab;
        }

        public void AttachView(PlayerView view)
        {
            m_PlayerView = view;
            m_PlayerView.AttachData(this);
        }

        public void SetPotionData(List<PotionData> data)
        {
            Potions = data;
        }
    }
}
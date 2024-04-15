using System.Collections.Generic;
using Assets;

namespace Player
{
    public class PlayerData
    {   
        private PlayerView m_PlayerView;
        private ItemAsset m_weapon;

        private List<ItemAsset> m_Potions;
        private List<ItemAsset> m_Throwers;

        public PlayerView PlayerView => m_PlayerView;
        public ItemAsset Weapon => m_weapon;

        public List<ItemAsset> Potions => m_Potions;
        public List<ItemAsset> Throwers => m_Throwers;

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

    }
}
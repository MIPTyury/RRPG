using UnityEngine;
using Assets;

namespace Player
{
    public class PlayerData
    {   
        private PlayerView m_PlayerView;

        public PlayerView PlayerView => m_PlayerView;

        public float maxHealth;
        public float currentHealth;
        public float maxMana;
        public float currentMana;
        public float maxStamina;
        public float currentStamina;
        public float speed;

        public PlayerData(PlayerAsset asset) {
            maxHealth = asset.maxHealth;
            currentHealth = maxHealth;
            maxMana = asset.maxMana;
            currentMana = maxMana;
            maxStamina = asset.maxStamina;
            currentStamina = maxStamina;
            speed = asset.speed;

            m_PlayerView = asset.ViewPrefab;
        }

        public void AttachView(PlayerView view)
        {
            m_PlayerView = view;
            m_PlayerView.AttachData(this);
        }

    }
}
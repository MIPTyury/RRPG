using Managers;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace Runtime
{
    public class HealthBar : MonoBehaviour
    {
        public RectTransform healthBarRectTransform;
        public Slider healthSlider;

        public float health = 0;
        public float maxHealth = 0;

        private float previousMaxHealth = 100f;

        private void Update()
        {
            healthSlider.minValue = 0;
            health = Game.Runtime.PlayerData.currentHealth;
            maxHealth = Game.Runtime.PlayerData.maxHealth;

            if (healthSlider.maxValue != Game.Runtime.PlayerData.maxHealth)
            {
                healthSlider.maxValue = Game.Runtime.PlayerData.maxHealth;
            }

            if (maxHealth != previousMaxHealth)
            {
                UpdateHealthBarSize(maxHealth);
                previousMaxHealth = maxHealth;
            }

            if (healthSlider.value != health)
            {
                healthSlider.value = health;
            }

            if (health <= 0)
            {
                AsyncOperation operation = SceneManager.LoadSceneAsync(0);
                DeathEventManager.SendEnemyDied();           
            }
        }

        private void UpdateHealthBarSize(float maxHealth)
        {
            float scaleFactor = maxHealth / previousMaxHealth;
            Vector2 newSize = new Vector2(healthBarRectTransform.sizeDelta.x * scaleFactor, healthBarRectTransform.sizeDelta.y);
            healthBarRectTransform.sizeDelta = newSize;
        }
    }
}

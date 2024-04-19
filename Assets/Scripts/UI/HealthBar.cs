using Managers;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace Runtime
{
    public class HealthBar : MonoBehaviour
    {
        public Slider healthSlider;

        public float health = 0;
        public float maxHealth = 0;

        void Update()
        {
            healthSlider.maxValue = Game.Runtime.PlayerData.maxHealth;
            healthSlider.minValue = 0;
            health = Game.Runtime.PlayerData.currentHealth;
            maxHealth = Game.Runtime.PlayerData.maxHealth;

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
    }
}
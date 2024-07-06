using Managers;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;


namespace Runtime
{
    public class HealthBar : MonoBehaviour
    {
        public RectTransform healthBarRectTransform;
        public Slider healthSlider;

        public float health = 0;
        public float maxHealth = 0;

        private float previousMaxHealth = 100f;

        private bool isDead = false;

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

            if (health <= 0 && !isDead)
            {   
                isDead = true;
                DeathEventManager.SendEnemyDied();          
            }
        }

        private IEnumerator HandleDeath()
            {
                // Send enemy died event
                AsyncOperation operation = SceneManager.LoadSceneAsync(1);
                //yield return new WaitUntil(() => operation.isDone);

                // Wait for 1 second
                Debug.Log("before delayed");
                yield return new WaitForSeconds(1);

                // Load the scene asynchronously
                Debug.Log("delayed");
                AsyncOperation operation1 = SceneManager.LoadSceneAsync(0);
                DeathEventManager.SendEnemyDied();
                // Optionally handle the operation (e.g., show loading screen)
            }

        private void UpdateHealthBarSize(float maxHealth)
        {
            float scaleFactor = maxHealth / previousMaxHealth;
            Vector2 newSize = new Vector2(healthBarRectTransform.sizeDelta.x * scaleFactor, healthBarRectTransform.sizeDelta.y);
            healthBarRectTransform.sizeDelta = newSize;
        }
    }
}

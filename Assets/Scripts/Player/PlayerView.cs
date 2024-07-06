using UnityEngine;
using Managers;
using System.Collections.Generic;
using Item;
using Runtime;
using System.Collections;
using UnityEngine.SceneManagement;
using System.Threading.Tasks;

namespace Player
{
    public class PlayerView : MonoBehaviour
    {
        private PlayerData m_PlayerData;

        public PlayerData PlayerData => m_PlayerData;

        public List<PotionView> Potions;
        public List<PotionView> Throwers;

        public void Awake()
        {
            DeathEventManager.OnEnemyDied.AddListener(Died);
        }

        public void AttachData(PlayerData data) 
        {
            m_PlayerData = data;
        }

public void Died()
        {
            if (Game.Runtime.PlayerData.currentHealth <= 0)
            {
                HandleDeathAsync(); // Call the async method directly
                Destroy(gameObject);
            }
        }

        private async void HandleDeathAsync()
        {
            // Send enemy died event
            AsyncOperation operation = SceneManager.LoadSceneAsync(1);

            await Task.Delay(1000); // Wait asynchronously for 1 second

            // Load the scene asynchronously
            AsyncOperation operation1 = SceneManager.LoadSceneAsync(0);
            // Optionally handle the operation (e.g., show loading screen)
        }
        public void SetPotionView(List<PotionView> view)
        {
            Potions = view;
        }
        
        void OnDrawGizmos()
        {
            
        }
        

    }
}

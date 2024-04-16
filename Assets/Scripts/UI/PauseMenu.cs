using UnityEngine;
using Utility;
using UnityEngine.SceneManagement;

namespace Runtime
{
    public class PauseMenu : MonoBehaviour
    {
        [SerializeField]
        private GameObject pauseMenu;

        private bool gamePaused = false;

        void Update()
        {
            if (Input.GetKeyDown(Controlls.SettingsKey))
            {
                if (gamePaused)
                {
                    Resume();
                }
                else
                {
                    Pause();
                }
            }
        }

        public void Pause()
        {
            pauseMenu.SetActive(true);
            Time.timeScale = 0f;
            gamePaused = true;
        }

        public void Resume()
        {
            pauseMenu.SetActive(false);
            Time.timeScale = 1f;
            gamePaused = false;
        }

        public void BackToMenu()
        {
            AsyncOperation operation = SceneManager.LoadSceneAsync(0);
            operation.completed += SetActiveGame;
        }

        private void SetActiveGame(AsyncOperation operation)
        {
            gamePaused = false;
            Time.timeScale = 1f;
        }
    }
}
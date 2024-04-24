using UnityEngine;
using Utility;

namespace Runtime
{
    public class InteractiveWindowOpener : MonoBehaviour
    {
        [SerializeField] private GameObject window;
        private void Update()
        {
            OpenWindow();
        }

        public void OpenWindow()
        {
            if (Input.GetKeyDown(Controlls.InteractionKey) && Physics2D.OverlapCircle(Game.Runtime.PlayerView.transform.Find("AttackPoint").transform.position, 1f, LayerMask.GetMask("Interactive")).gameObject != null)
            {
                window.SetActive(true);
                Time.timeScale = 0f;
            }
        }

        public void CloseWindow()
        {
            window.SetActive(false);
            Time.timeScale = 1f;
        }
    }
}
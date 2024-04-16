using Assets;
using UnityEngine;

namespace Runtime
{
    public class Menu : MonoBehaviour
    {
        [SerializeField]
        private AssetRoot m_AssetRoot;

        private void Awake()
        {
            Game.SetAssetRoot(m_AssetRoot);
        }

        public void StartGame()
        {
            Game.InitCurrentLocation(m_AssetRoot.Locations[0]);
        }

        public void ExitGame()
        {
            Debug.Log("Exited game");
            Application.Quit();
        }
    }
}
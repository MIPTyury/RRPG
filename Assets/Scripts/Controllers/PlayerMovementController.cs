using Assets;
using UnityEngine;

namespace Runtime
{
    public class PlayerMovementController : IController
    {   
        private PlayerSpawnerAsset m_PlayerSpawnerAsset;

        public PlayerMovementController (PlayerSpawnerAsset PlayerSpawnerAsset)
        {
            m_PlayerSpawnerAsset = PlayerSpawnerAsset;
        }
        public void OnStart() 
        {
            // Debug.Log("OnStart was called");
        }

        public void OnStop() 
        {
            // Debug.Log("OnStop was called");
        }

        public void OnTick () 
        {
            MovePlayer(m_PlayerSpawnerAsset.PlayerAsset);
        }

        private void MovePlayer(PlayerAsset asset)
        {   
            float moveX = Input.GetAxisRaw("Horizontal");
            float moveY = Input.GetAxisRaw("Vertical");

            Vector3 moveDir = new Vector3(moveX, moveY, 0).normalized;

            Game.Runtime.PlayerView.transform.Translate(moveDir * asset.speed * Time.deltaTime);
        }
    }
    
}
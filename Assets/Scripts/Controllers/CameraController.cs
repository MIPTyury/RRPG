using System.Numerics;
using Assets;
using UnityEngine;

namespace Runtime
{
    public class CameraController : IController
    {   
        private PlayerSpawnerAsset m_PlayerSpawnerAsset;
        private Camera m_Camera;

        public CameraController (PlayerSpawnerAsset PlayerSpawnerAsset)
        {
            m_PlayerSpawnerAsset = PlayerSpawnerAsset;
        }
        public void OnStart() 
        {
            m_Camera = Object.FindObjectOfType<Camera>();
        }

        public void OnStop() 
        {
            // Debug.Log("OnStop was called");
        }

        public void OnTick () 
        {
            TrackPlayer(m_PlayerSpawnerAsset.PlayerAsset, m_Camera);
        }

        private void TrackPlayer(PlayerAsset asset, Camera camera)
        {   
            UnityEngine.Vector3 PlayerPos = Game.Runtime.PlayerView.transform.position;
            UnityEngine.Vector3 CameraPos = new UnityEngine.Vector3(PlayerPos.x, PlayerPos.y, PlayerPos.z - 10f);
            m_Camera.transform.position = CameraPos;
        }
    }
    
}
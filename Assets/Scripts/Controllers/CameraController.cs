using UnityEngine;
using Cinemachine;

namespace Runtime
{
    public class CameraController : IController
    {   
        private CinemachineVirtualCamera m_CinemachineVirtualCamera;
        public void OnStart() 
        {
            m_CinemachineVirtualCamera = Object.FindObjectOfType<CinemachineVirtualCamera>();
        }

        public void OnStop() 
        {
            
        }

        public void OnTick () 
        {
            TrackPlayer();
        }

        private void TrackPlayer()
        {   
            m_CinemachineVirtualCamera.Follow = Game.Runtime.PlayerView.transform;
        }
    }
    
}
using System.Numerics;
using Assets;
using UnityEngine;

namespace Runtime
{
    public class CameraController : IController
    {   
        private Camera m_Camera;
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
            TrackPlayer();
        }

        private void TrackPlayer()
        {   
            UnityEngine.Vector3 PlayerPos = Game.Runtime.PlayerView.transform.position;
            m_Camera.transform.position = UnityEngine.Vector3.Lerp(m_Camera.transform.position, PlayerPos, 2*Time.deltaTime);
            m_Camera.transform.position = new UnityEngine.Vector3(m_Camera.transform.position.x, m_Camera.transform.position.y, -10);
        }
    }
    
}
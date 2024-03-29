using System;
using System.Collections.Generic;
using UnityEngine;

namespace Runtime
{
    public class Runner : MonoBehaviour 
    {
        private List<IController> m_Controllers = new List<IController>();
        private bool m_IsRunning = false;

        private void Update()
        {   
            if (!m_IsRunning) 
            {
                return;
            }

            TickControllers();
        }

        public void StartRunning()
        {
            CreateAllControllers();
            OnStartControllers();
            m_IsRunning = true;
        }

        public void StopRunning()
        {   
            OnStopControllers();
            m_IsRunning = false;
        }

        private void CreateAllControllers()
        {
            m_Controllers = new List<IController>()
            {
                new PlayerSpawnController(Game.CurrentLocation.PlayerSpawnerAsset),
                new PlayerMovementController(Game.CurrentLocation.PlayerSpawnerAsset),
                new CameraController(Game.CurrentLocation.PlayerSpawnerAsset),
                new EnemySpawnController(Game.CurrentLocation.EnemyTypes),
                new PlayerDamageController(Game.CurrentLocation.PlayerSpawnerAsset),
            };
        }

        private void OnStartControllers()
        {
            foreach (IController controller in m_Controllers)
            {
                try
                {
                    controller.OnStart();
                }
                catch (Exception e)
                {
                    Debug.LogError(e);
                }
            }
        }

        private void OnStopControllers()
        {
            foreach (IController controller in m_Controllers)
            {
                try
                {
                    controller.OnStop();
                }
                catch (Exception e)
                {
                    Debug.LogError(e);
                }
            }
        }

        private void TickControllers()
        {
            foreach (IController controller in m_Controllers)
            {
                try
                {
                    controller.OnTick();
                }
                catch (Exception e)
                {
                    Debug.LogError(e);
                }
            }
        }


    }
}
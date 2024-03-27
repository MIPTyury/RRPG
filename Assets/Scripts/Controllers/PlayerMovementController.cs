using Assets;
using UnityEngine;
using System.Collections.Generic;

namespace Runtime
{
    public class PlayerMovementController : IController
    {   
        private PlayerSpawnerAsset m_PlayerSpawnerAsset;
        private Animator m_Animator;
        private Dictionary<Vector2, float> angleToMoveDirection = new Dictionary<Vector2, float>();

        public PlayerMovementController (PlayerSpawnerAsset PlayerSpawnerAsset)
        {
            m_PlayerSpawnerAsset = PlayerSpawnerAsset;

            float[] angles = { 337.5f, 292.5f, 247.5f, 202.5f, 157.5f, 112.5f, 67.5f, 22.5f };
            for (int i = 0; i < angles.Length; i++)
            {
                angleToMoveDirection[new Vector2(angles[(i + 1) % angles.Length], angles[i])] = (i + 3) % 8;
            }
        }
        public void OnStart() 
        {
            m_Animator = Game.Runtime.PlayerView.GetComponent<Animator>();
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

            SetMoveDirectionParameter(moveDir);

            Game.Runtime.PlayerView.transform.Translate(moveDir * asset.speed * Time.deltaTime);
        }

        private void SetMoveDirectionParameter(Vector3 moveDir)
        {
            float angle = Mathf.Atan2(moveDir.y, moveDir.x) * Mathf.Rad2Deg;
            angle = (angle < 0) ? angle + 360 : angle;

            float moveDirectionValue = GetMoveDirectionValue(angle);
            Debug.Log(angle);

            m_Animator.SetFloat("moveDirection", moveDirectionValue);
        }

        private float GetMoveDirectionValue(float angle)
        {   
            if (angle == 0)
            {
                return 2;
            }

            foreach (var entry in angleToMoveDirection)
            {   
                if (angle >= entry.Key.x && angle < entry.Key.y)
                {
                    return entry.Value;
                }
            }

            return 0;
        }
    }
    
}
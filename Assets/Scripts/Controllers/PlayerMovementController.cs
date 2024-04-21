using UnityEngine;

namespace Runtime
{
    public class PlayerMovementController : IController
    {   
        private Animator m_Animator;
        private Vector2 Direction;
        private Vector3 MotionDirection;

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
            MovePlayer();
        }

        private void MovePlayer()
        {   
            float moveX = Input.GetAxisRaw("Horizontal");
            float moveY = Input.GetAxisRaw("Vertical");
            Direction.x = moveX;
            Direction.y = moveY;
            MotionDirection.x = moveX;
            MotionDirection.y = moveY;
            MotionDirection.z = 0;
            MotionDirection = MotionDirection.normalized;

            float speed = Direction.sqrMagnitude;

            m_Animator.SetFloat("Horizontal", moveX);
            m_Animator.SetFloat("Vertical", moveY);
            m_Animator.SetFloat("Speed", speed);

            Game.Runtime.PlayerView.transform.Translate(MotionDirection * Game.Runtime.PlayerData.speed * Time.deltaTime);
        }
    }
    
}
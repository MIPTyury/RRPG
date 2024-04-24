using UnityEngine;

namespace Runtime
{
    public class PlayerMovementController : IController
    {   
        private Animator m_Animator;
        private Vector2 Direction;
        private Vector3 MotionDirection;
        private Rigidbody2D rigidbody2D;
        public void OnStart() 
        {
            m_Animator = Game.Runtime.PlayerView.GetComponent<Animator>();
            rigidbody2D = Game.Runtime.PlayerView.GetComponent<Rigidbody2D>();
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

            Vector3 Pos = Game.Runtime.PlayerView.transform.position;
            Vector3 NewPos = Pos + Game.Runtime.PlayerData.speed * Time.fixedDeltaTime * MotionDirection;

            rigidbody2D.MovePosition(rigidbody2D.position + Direction.normalized*Game.Runtime.PlayerData.speed*Time.fixedDeltaTime);
            // Game.Runtime.PlayerView.transform.position = Vector3.MoveTowards(Pos, NewPos, Time.deltaTime * Game.Runtime.PlayerData.speed);
        }
    }
    
}
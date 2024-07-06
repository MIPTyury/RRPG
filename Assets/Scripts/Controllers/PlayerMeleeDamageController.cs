using UnityEngine;
using Managers;
using Enemy;
using System.Collections.Generic;
using Utility;
using System.Collections;
using Unity.VisualScripting;

namespace Runtime
{
    public class PlayerMeleeDamageController : IController
    {   

        private Animator m_Animator;
        public float slashDuration = 1f;

        public PlayerMeleeDamageController ()
        {

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
            GiveDamage();
        }
        private void GiveDamage() 
        {   
            if (Input.GetKeyDown(Controlls.AttackKey)) 
            {
                SetSlashAngle();
            }
        }

        private void SetSlashAngle()
        {
            Transform slashTransform = Game.Runtime.PlayerView.transform.Find("Slash").transform;
            Vector3 currentRotation = slashTransform.rotation.eulerAngles;
            Vector3 newRotation = new Vector3(currentRotation.x, currentRotation.y, GetAngle());
            slashTransform.rotation = Quaternion.Euler(newRotation);
            Game.Runtime.PlayerView.transform.Find("Slash").gameObject.SetActive(true);

            Game.Runtime.PlayerView.StartCoroutine(DisableSlashAfterDelay());
        }

        private IEnumerator DisableSlashAfterDelay()
        {
            Game.Runtime.PlayerView.transform.Find("Slash").gameObject.SetActive(true); // Включаем объект "Slash"
            GetTarget();

            yield return new WaitForSeconds(slashDuration);

            Game.Runtime.PlayerView.transform.Find("Slash").gameObject.SetActive(false);
        }


        private float GetAngle()
        {
            Vector3 centerScreen = new Vector3(Screen.width / 2f, Screen.height / 2f, 0f);
            Vector3 mousePos = Input.mousePosition;
            Vector3 relativeMousePos = mousePos - centerScreen;

            float angle = Mathf.Atan2(relativeMousePos.y, relativeMousePos.x) * Mathf.Rad2Deg;

            return angle;
        }


        private void GetTarget()
        {
            Vector2 attackPointPosition = (Vector2)Game.Runtime.PlayerView.transform.Find("Slash").Find("Capsule").position;

            Vector3 slashSizeFrom = Game.Runtime.PlayerView.transform.Find("Slash").GetComponent<Collider2D>().bounds.size;

            Vector2 slashSize = new(slashSizeFrom.x, slashSizeFrom.y);

            LayerMask enemyLayerMask = LayerMask.GetMask("Enemies");

            Collider2D[] hitColliders = Physics2D.OverlapCapsuleAll(attackPointPosition, slashSize, CapsuleDirection2D.Horizontal, GetAngle(), enemyLayerMask);

            List<Collider2D> hitEnemies = new List<Collider2D>(hitColliders);

            
            List<GameObject> enemies = GetUnique(hitEnemies);

            foreach (var enemy in enemies)
            {
                EnemyView view = enemy.GetComponent<EnemyView>();
                EnemyData data = Game.Runtime.Enemies[view];

                float test = data.currentHealth;
                data.currentHealth -= Game.Runtime.PlayerData.Weapon.Value;
                Debug.Log($"Урон - {Game.Runtime.PlayerData.Weapon.Value}, Снялось {test - data.currentHealth}");
                view.AttachData(data);
            }

            DeathEventManager.SendEnemyDied();
        }

        private List<GameObject> GetUnique(List<Collider2D> list)
        {
            HashSet<GameObject> uniqueObjects = new HashSet<GameObject>();

            foreach (var collider in list)
            {
                uniqueObjects.Add(collider.gameObject);
            }

            return new List<GameObject>(uniqueObjects);
        }
    }
}
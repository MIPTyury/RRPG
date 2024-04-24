using UnityEngine;
using System.Collections.Generic;
using Item;
using Utility;

namespace Runtime
{
    public class PickUpItemController : IController
    {   
        public PickUpItemController ()
        {
    
        }
        public void OnStart() 
        {
            
        }

        public void OnStop() 
        {
            
        }

        public void OnTick () 
        {
            if (Input.GetKeyDown(Controlls.InteractionKey))
            {
                GetPotions();
            }
        }

        public void GetPotions()
        {
            List<Collider2D> hitPotions = new List<Collider2D>(Physics2D.OverlapCircleAll(Game.Runtime.PlayerView.transform.Find("AttackPoint").transform.position, 0.6f, LayerMask.GetMask("Potions")));

            foreach (Collider2D element in hitPotions)
            {
                PotionView potion = element.GetComponentInParent<PotionView>();

                if (potion != null)
                {
                    Debug.Log("Зелье должно быть добавленои уничтожено");
                    Game.Runtime.PlayerData.Potions.Add(potion.PotionData);
                    Game.Runtime.PlayerView.Potions.Add(potion);
                    GameObject.Destroy(element.gameObject);
                }
                else
                {
                    Debug.Log("Проблема с зельем");
                }
            }
        }
    }
}
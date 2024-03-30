using System;
using Enemy;
using UnityEngine;
using UnityEngine.Events;

namespace Managers
{
    public class DeathEventManager
    {
        public static UnityEvent OnEnemyDied = new UnityEvent();

        public static void SendEnemyDied ()
        {
            OnEnemyDied.Invoke();
        }
    }
}
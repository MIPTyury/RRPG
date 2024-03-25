using UnityEngine;
using System.Collections.Generic;
using Enemy;

namespace Assets
{
    [CreateAssetMenu(menuName = "Asset/Enemy Asset", fileName = "Enemy Asset")]
    public class EnemyAsset : ScriptableObject
    {
        public int StartHealth;

        public EnemyView ViewPrefab;
    }
}
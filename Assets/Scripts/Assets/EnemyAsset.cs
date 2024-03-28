using UnityEngine;
using Enemy;

namespace Assets
{
    [CreateAssetMenu(menuName = "Asset/Enemy Asset", fileName = "Enemy Asset")]
    public class EnemyAsset : ScriptableObject
    {
        public float maxHealth;
        public Vector3 Position;
        public EnemyView ViewPrefab;
    }
}
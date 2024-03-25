using UnityEngine;
using System.Collections.Generic;

namespace Assets
{
    [CreateAssetMenu(menuName = "Asset/EnemyType Asset", fileName = "EnemyType Asset")]
    public class EnemyTypeAsset : ScriptableObject
    {
        public List<EnemyAsset> Enemy;
    }
}
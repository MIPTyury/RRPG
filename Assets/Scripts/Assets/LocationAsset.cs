using UnityEngine;
using System.Collections.Generic;

namespace Assets
{
    [CreateAssetMenu(menuName = "Asset/Location Asset", fileName = "Location Asset")]
    public class LocationAsset : ScriptableObject
    {
        public List<EnemyTypeAsset> EnemyTypes;
    }
}
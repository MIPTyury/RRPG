using UnityEngine;
using System.Collections.Generic;

namespace Assets
{
    [CreateAssetMenu(menuName = "Asset/Location Asset", fileName = "Location Asset")]
    public class LocationAsset : ScriptableObject
    {   
        public string SceneAsset;
        public PlayerAsset PlayerAsset;
        public List<EnemyAsset> EnemyTypes;

        [Header("Предметы")]
        public List<PotionAsset> Potions;
    }
}
using UnityEngine;
using System.Collections.Generic;
using UnityEditor;

namespace Assets
{
    [CreateAssetMenu(menuName = "Asset/Location Asset", fileName = "Location Asset")]
    public class LocationAsset : ScriptableObject
    {   
        public SceneAsset SceneAsset;
        public PlayerSpawnerAsset PlayerSpawnerAsset;
        public List<EnemyTypeAsset> EnemyTypes;
    }
}
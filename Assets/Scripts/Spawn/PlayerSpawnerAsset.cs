using UnityEngine;

namespace Assets
{
    [CreateAssetMenu(menuName = "Asset/Spawner Asset", fileName = "Spawner Asset")]
    public class PlayerSpawnerAsset : ScriptableObject
    {
        public PlayerAsset PlayerAsset;
    }
}
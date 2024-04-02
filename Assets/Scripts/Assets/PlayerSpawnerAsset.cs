using UnityEngine;

namespace Assets
{
    [CreateAssetMenu(menuName = "Asset/Player Spawner Asset", fileName = "Player Spawner Asset")]
    public class PlayerSpawnerAsset : ScriptableObject
    {
        public PlayerAsset PlayerAsset;
    }
}
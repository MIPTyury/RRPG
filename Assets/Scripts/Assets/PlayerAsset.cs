using UnityEngine;
using Player;

namespace Assets
{
    [CreateAssetMenu(menuName = "Asset/Player Asset", fileName = "Player Asset")]
    public class PlayerAsset : ScriptableObject
    {
        public float maxHealth;
        public float maxMana;
        public float maxStamina;
        public float speed;
        
        public PlayerView ViewPrefab;
    }
}
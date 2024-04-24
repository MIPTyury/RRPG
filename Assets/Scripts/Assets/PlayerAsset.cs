using UnityEngine;
using Player;
using System.Collections.Generic;

namespace Assets
{
    [CreateAssetMenu(menuName = "Asset/Player Asset", fileName = "Player Asset")]
    public class PlayerAsset : ScriptableObject
    {
        public float maxHealth;
        public float maxMana;
        public float maxStamina;
        public float speed;
         
        public WeaponAsset WeaponAsset;

        public List<PotionAsset> Potions;
        public List<ItemAsset> Throwers;
        public PlayerView ViewPrefab;
    }
}
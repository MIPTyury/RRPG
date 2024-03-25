using UnityEngine;
using System.Collections.Generic;

namespace Assets
{
    [CreateAssetMenu(menuName = "Asset/Asset Root", fileName = "Asset Root")]
    public class AssetRoot : ScriptableObject
    {
        public List<LocationAsset> Locations;
    }
}
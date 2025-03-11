namespace MageSurvivor.Code.Abilities.Abstract
{
    using MageSurvivor.Code.Abilities.Sources;
    using UnityEngine;
    using UnityEngine.AddressableAssets;

    public class DamageProjectileData : GeneralAbilityData
    {
        public int Damage;
        public float Range;
        public float Speed;
        public AssetReferenceT<GameObject> ProjectilePrefab;
    }
}
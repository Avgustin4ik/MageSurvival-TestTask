namespace MageSurvivor.Code.Abilities.Abstract
{
    using System;
    using Common.Projectile;
    using UnityEngine;

    [Serializable]
    public class DamageProjectileData : GeneralAbilityData
    {
        public int Damage;
        public float Range;
        public float Speed;
        public ProjectileMono ProjectilePrefab;
    }
}
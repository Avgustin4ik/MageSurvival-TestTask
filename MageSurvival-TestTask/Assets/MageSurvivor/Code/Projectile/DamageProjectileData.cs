namespace MageSurvivor.Code.Projectile
{
    using System;

    [Serializable]
    public class DamageProjectileData : GeneralAbilityData
    {
        public int Damage;
        public float Range;
        public float Speed;
        public ProjectileMono ProjectilePrefab;
    }
}
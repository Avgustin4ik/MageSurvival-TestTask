namespace MageSurvivor.Code.Abilities.Abstract
{
    using Projectile;
    using Sources;
    using UnityEngine;

    public interface IAbility
    {
        DamageProjectileData Data { get; }
        public void SetData(DamageProjectileData data);
        public bool Initialized { get; }
        bool UseAtTarget(GameObject caster, GameObject target);
        bool Use(GameObject caster, Vector3 direction);
    }
}
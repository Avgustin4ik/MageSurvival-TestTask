namespace MageSurvivor.Code.Abilities.Abstract
{
    using System;
    using JetBrains.Annotations;
    using Projectile;
    using UnityEngine;

    public abstract class Ability<T> : IAbility where T : DamageProjectileData
    {
        public DamageProjectileData Data { get; private set; }

        public void SetData([NotNull] DamageProjectileData data)
        {
            Data = data ?? throw new ArgumentNullException(nameof(data));
        }
        public bool Initialized => Data != null;
        public bool UseAtTarget(GameObject caster, GameObject target)
        {
            throw new NotImplementedException();
        }

        public virtual bool Use(GameObject caster, Vector3 direction)
        {
            throw new NotImplementedException();
        }

        public virtual bool Use(GameObject caster, GameObject target)
        {
            throw new System.NotImplementedException();
        }
    }
    
}
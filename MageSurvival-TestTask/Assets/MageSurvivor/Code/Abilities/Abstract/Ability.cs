﻿namespace MageSurvivor.Code.Abilities.Abstract
{
    using System;
    using global::Code.Core.Factories;
    using JetBrains.Annotations;
    using Sources;
    using UnityEngine;

    public abstract class Ability<T> : IAbility where T : DamageProjectileData
    {
        public DamageProjectileData Data { get; private set; }

        public void SetData([NotNull] DamageProjectileData data)
        {
            Data = data ?? throw new ArgumentNullException(nameof(data));
        }
        public bool Initialized => Data != null;
        public virtual bool Use(GameObject caster, GameObject target)
        {
            throw new System.NotImplementedException();
        }
    }
    
}
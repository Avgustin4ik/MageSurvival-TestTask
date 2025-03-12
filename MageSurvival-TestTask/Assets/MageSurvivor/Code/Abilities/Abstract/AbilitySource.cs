namespace MageSurvivor.Code.Abilities.Abstract
{
    using System;
    using Sources;
    using UnityEngine;

    public abstract class AbilitySource : ScriptableObject
    {
        public abstract string AbilityType { get; }
        public DamageProjectileData Data;
        public abstract IAbility CreateAbility();
    }
    
    
    public class AbilitySource<T> : AbilitySource where T : Ability<DamageProjectileData>, new()
    {
        public override string AbilityType => typeof(T).Name;
        public override IAbility CreateAbility()
        {
            var ability = new T();
            ability.SetData(Data);
            return ability;
        }
    }
}
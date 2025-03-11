namespace MageSurvivor.Code.Abilities.Abstract
{
    using Sources;
    using UnityEngine;

    public abstract class AbilitySource : ScriptableObject
    {
        public abstract IAbility CreateAbility(DamageProjectileData data);
    }
    
    
    public class AbilitySource<T> : AbilitySource where T : Ability<DamageProjectileData>, new()
    {
        public override IAbility CreateAbility(DamageProjectileData data)
        {
            var ability = new T();
            ability.SetData(data);
            return new T();
        }
    }
}
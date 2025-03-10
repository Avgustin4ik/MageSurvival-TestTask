namespace MageSurvivor.Code.Abilities.Abstract
{
    using UnityEngine;

    public abstract class AbilitySource : ScriptableObject
    {
        public abstract IAbility CreateAbility();
    }
    
    
    public class AbilitySource<T> : AbilitySource where T : Ability, new()
    {
        public override IAbility CreateAbility()
        {
            return new T();
        }
    }
}
namespace MageSurvivor.Code.Abilities.Abstract
{
    using UnityEngine;

    public abstract class Ability : IAbility
    {
        public virtual bool Use(GameObject caster, GameObject target)
        {
            throw new System.NotImplementedException();
        }
    }
    
}
namespace MageSurvivor.Code.Abilities.Abstract
{
    using UnityEngine;

    public interface IAbility
    {
        bool Use(GameObject caster, GameObject target);
    }
}
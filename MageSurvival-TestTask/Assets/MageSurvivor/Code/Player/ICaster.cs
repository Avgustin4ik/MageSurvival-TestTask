namespace MageSurvivor.Code.Player
{
    using System.Collections.Generic;
    using Abilities;
    using Abilities.Abstract;
    using UnityEngine;

    public interface ICaster
    {
        void EquipAbility(IAbility ability);
        AbilityPool Abilities { get;}
        void SelectAbility(int index);
        void UseAbility(GameObject caster, GameObject target);
        void UseAbility<T>(GameObject target) where T : IAbility;
        void UseAbility(IAbility ability, GameObject target);
    }
}
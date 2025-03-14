namespace MageSurvivor.Code.Unit
{
    using MageSurvivor.Code.Abilities;
    using MageSurvivor.Code.Abilities.Abstract;
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
namespace MageSurvivor.Code.Player
{
    using System.Collections.Generic;
    using Abilities.Abstract;
    using UnityEngine;

    public interface ICaster
    {
        IEnumerable<IAbility> Abilities { get; }
        void SelectAbility(int index);
        void UseAbility(GameObject target);
        void UseAbility<T>(GameObject target) where T : IAbility;
        void UseAbility(IAbility ability, GameObject target);
    }
}
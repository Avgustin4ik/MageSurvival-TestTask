namespace MageSurvivor.Code.Abilities
{
    using System.Collections.Generic;
    using MageSurvivor.Code.Abilities.Abstract;
    using UnityEngine;

    public class AbilityPool : List<IAbility>
    {
        public bool UseSelectedAbility(GameObject caster, GameObject target)
        {
            return this[SelectedAbilityIndex].Use(caster, target);
        }
        public int SelectedAbilityIndex { get; private set; }
        public AbilityPool()
        {
            Add(new FireballAbility());
            Add(new IceBoltAbility());
            Add(new LightningBoltAbility());
            SelectedAbilityIndex = 0;
        }
        public void SelectAbility(int index)
        {
            SelectedAbilityIndex = index;
        }

        public void GetNextAbility()
        {
            Debug.Log("GetNextAbility");
            SelectedAbilityIndex = (SelectedAbilityIndex + 1) % Count;
        }

        public void GetPreviousAbility()
        {
            Debug.Log("GetPreviousAbility");
            SelectedAbilityIndex = (SelectedAbilityIndex - 1 + Count) % Count;
        }
    }
}
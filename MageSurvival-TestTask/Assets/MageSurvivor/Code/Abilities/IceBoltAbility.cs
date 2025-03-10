namespace MageSurvivor.Code.Abilities
{
    using Abstract;
    using UnityEngine;

    public class IceBoltAbility : Ability
    {
        public override bool Use(GameObject caster, GameObject target)
        {
            Debug.Log("IceBoltAbility used");
            return true;
        }
    }
}
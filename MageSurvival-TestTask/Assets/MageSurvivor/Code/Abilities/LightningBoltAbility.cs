﻿namespace MageSurvivor.Code.Abilities
{
    using Abstract;
    using UnityEngine;

    public class LightningBoltAbility : Ability<DamageProjectileData>
    {
        public override bool Use(GameObject caster, GameObject target)
        {
            Debug.Log("LightningBoltAbility used");
            return true;
        }
    }
}
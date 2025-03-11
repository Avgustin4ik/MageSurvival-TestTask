namespace MageSurvivor.Code.Abilities
{
    using Abstract;
    using Sources;
    using UnityEngine;

    public class FireballAbility : Ability<DamageProjectileData>
    {
        
        public override bool Use(GameObject caster, GameObject target)
        {
            Debug.Log("FireballAbility used");
            //spawn fireball at caster position
            
            // _spawnService.SpawnInstanceAsync()
            //spawn as poolable object
            
            //spawn as projectile
            return true;
        }
    }
}
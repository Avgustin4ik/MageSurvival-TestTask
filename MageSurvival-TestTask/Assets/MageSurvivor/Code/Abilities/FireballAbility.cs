namespace MageSurvivor.Code.Abilities
{
    using Abstract;
    using Common.Projectile;
    using UnityEngine;

    public class FireballAbility : Ability<DamageProjectileData>
    {
        public override bool Use(GameObject caster, Vector3 direction)
        {
            Debug.Log("FireballAbility used");
            //spawn fireball at caster position
            if (Data == null)
            {
                Debug.LogError("Data is null");
                return false;
            }
            var projectile = Object.Instantiate<ProjectileMono>(Data.ProjectilePrefab, caster.transform.position, Quaternion.identity);
            //spawn as projectile
            projectile.Lunch(direction, Data.Speed);
            //spawn as poolable object
            
            return true;
        }
    }
}
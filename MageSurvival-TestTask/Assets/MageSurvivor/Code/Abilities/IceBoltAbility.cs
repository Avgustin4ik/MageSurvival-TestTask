namespace MageSurvivor.Code.Abilities
{
    using Abstract;
    using Projectile;
    using UnityEngine;

    public class IceBoltAbility : Ability<DamageProjectileData>
    {
        public override bool Use(GameObject caster, Vector3 direction)
        {
            Debug.Log($"{nameof(IceBoltAbility)} used");
            if (Data == null)
            {
                Debug.LogError("Data is null");
                return false;
            }
            var projectile = Data.ProjectilePrefab;
            Debug.Log("projectile reference: " + projectile);
            var p = projectile.Spawn<ProjectileMono>(caster.transform.position, Quaternion.LookRotation(direction));
            p.SetData(Data);
            p.LaunchForward(Data.Speed);
            return true;
        }
    }
}
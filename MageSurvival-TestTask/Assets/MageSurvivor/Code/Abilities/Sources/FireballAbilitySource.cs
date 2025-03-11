namespace MageSurvivor.Code.Abilities.Sources
{
    using Abstract;
    using UnityEngine;

    [CreateAssetMenu(fileName = "FireballAbilitySource", menuName = "MageSurvivor/Ability/Source/Fireball")]
    public class FireballAbilitySource : AbilitySource<FireballAbility>
    {
        public DamageProjectileData projectileData;
        public override IAbility CreateAbility(DamageProjectileData data)
        {
            return base.CreateAbility(projectileData);
        }
    }
}
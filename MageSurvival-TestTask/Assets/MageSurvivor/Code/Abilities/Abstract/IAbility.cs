namespace MageSurvivor.Code.Abilities.Abstract
{
    using Sources;
    using UnityEngine;

    public interface IAbility
    {
        DamageProjectileData Data { get; }
        public void SetData(DamageProjectileData data);
        public bool Initialized { get; }
        bool Use(GameObject caster, GameObject target);
    }
}
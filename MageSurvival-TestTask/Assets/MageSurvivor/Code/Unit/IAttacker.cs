namespace MageSurvivor.Code.Unit
{
    using UnitFactory.Abstract;
    using UnityEngine;

    public interface IAttacker
    {
        float AttackRange { get; set; }
        float Damage { get; }
        void TryAttack(CharacterUnitBase target);

        public void SetTarget(CharacterUnitBase target);
    }
}
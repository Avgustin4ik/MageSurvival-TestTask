namespace MageSurvivor.Code.Unit
{
    using UnityEngine;

    public interface IAttacker
    {
        float AttackRange { get; set; }
        int Damage { get; }
        void TryAttack(IDamageable target);
    }
}
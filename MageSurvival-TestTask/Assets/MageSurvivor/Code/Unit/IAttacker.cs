namespace MageSurvivor.Code.Unit
{
    using UnityEngine;

    public interface IAttacker
    {
        float AttackRange { get; set; }
        float Damage { get; }
        void TryAttack(IDamageable target);

        public void SetTarget(IDamageable target);
    }
}
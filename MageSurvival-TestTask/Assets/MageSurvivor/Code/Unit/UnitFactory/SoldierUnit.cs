namespace MageSurvivor.Code.Unit.UnitFactory
{
    using Abstract;
    using UniRx;
    using UnityEngine;

    public class SoldierUnit : AttackerUnit
    {
        public float AttackRange { get; set; }
        public float Damage { get; private set; }
        public void TryAttack(IDamageable target)
        {
            target.TakeDamage(Damage);
        }

        public override void SetConfig(Config config)
        {
            AttackRange = config.AttackRange;
            Damage = config.Damage;
            base.SetConfig(config);
        }
    }
    
    public class AttackerUnit : CharacterUnitBase, IAttacker
    {
        public IDamageable _target { get; set; }
        public float AttackRange { get; set; }
        public float Damage { get; private set; }
        private readonly ReactiveProperty<Vector3> _position = new ReactiveProperty<Vector3>();
        public void TryAttack(IDamageable target)
        {
            target.TakeDamage(Damage);
        }

        public void SetTarget(IDamageable target)
        {
            _position
                .SkipWhile(x => Vector3.Distance(x, target.position) > 2)
                .Subscribe(_ => TryAttack(target));
        }
        
    }
}
namespace MageSurvivor.Code.Unit.UnitFactory
{
    using System;
    using Abstract;
    using UniRx;
    using UnityEngine;

    public class AttackerUnit : CharacterUnitBase, IAttacker
    {
        private IDisposable _stream;
        public IDamageable _target { get; set; }
        public float AttackRange { get; set; }
        public float Damage { get; private set; }

        public void TryAttack(IDamageable target)
        {
            Debug.Log("AttackerUnit TryAttack");
            target.TakeDamage(Damage);
        }

        public void SetTarget(IDamageable target)
        {
            Observable.EveryUpdate()
                .SkipWhile(x => Vector3.Distance(position, target.position) > 2)
                .Subscribe(_ => TryAttack(target))
                .AddTo(this.Disposables);
        }
    }
}
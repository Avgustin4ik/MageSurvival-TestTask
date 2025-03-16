namespace MageSurvivor.Code.Unit.UnitFactory
{
    using System;
    using Abstract;
    using UniRx;
    using UnityEngine;

    public class AttackerUnit : CharacterUnitBase, IAttacker
    {
        private IDisposable _stream;
        private bool _isAttacking;
        public IDamageable _target { get; set; }
        public float AttackRange { get; set; }
        public float Damage { get; private set; }
        private IDisposable _attackCooldown;
        public void TryAttack(IDamageable target)
        {
            if(_isAttacking) return;
            _isAttacking = true;
            Debug.Log("AttackerUnit TryAttack");
            target.TakeDamage(Damage);
            
            _attackCooldown.Dispose();
            _attackCooldown = Observable.Timer(TimeSpan.FromSeconds(1f/Config.AttackSpeed))
                .Subscribe(_ => _isAttacking = false)
                .AddTo(this.Disposables);
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
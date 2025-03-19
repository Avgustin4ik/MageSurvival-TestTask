namespace MageSurvivor.Code.Unit.UnitFactory
{
    using System;
    using Abstract;
    using Common;
    using UniRx;
    using UnityEngine;

    public class AttackerUnit : CharacterUnitBase, IAttacker
    {
        private IDisposable _stream;
        private bool _isAttacking;
        public IDamagable _target { get; set; }
        public float AttackRange { get; set; }
        public float Damage { get; private set; }
        public void TryAttack(CharacterUnitBase target)
        {
            if(_isAttacking) return;
            _isAttacking = true;
            Debug.Log("AttackerUnit TryAttack");
            target.TakeDamage(Damage);
            
            Observable.Timer(TimeSpan.FromSeconds(1f/Config.AttackSpeed))
                .Subscribe(_ => _isAttacking = false)
                .AddTo(this.Disposables);
        }

        public void SetupTarget(CharacterUnitBase target)
        {
            
            _stream = Observable.EveryUpdate()
                .SkipWhile(x => Vector3.Distance(this.position, target.position) > 2)
                .Subscribe(_ => TryAttack(target))
                .AddTo(this.Disposables);
            
            target.IsDead.Subscribe(x => { if(x) _stream.Dispose();}).AddTo(this.Disposables);
        }
    }
}
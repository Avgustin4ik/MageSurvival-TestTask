namespace MageSurvivor.Code.Unit
{
    using System;
    using UniRx;
    using UnityEngine;

    public class Enemy : CharacterUnit, IAttacker
    {
        public int Damage { get; }

        private ReactiveProperty<UnityEngine.Vector3> _position = new();
        public float AttackRange { get; set; }
        private bool _isAttacking;
        
        public Enemy()
        {
        }

        public void TryAttack(IDamageable target)
        {
            if(_isAttacking) return;
            Debug.Log("TryAttack");
            target.TakeDamage(Damage);
        }

        public void SetPosition(Vector3 cachedTransformPosition)
        {
            _position.Value = cachedTransformPosition;
        }

        public void SetTarget(IDamageable target)
        {
            _position
                .SkipWhile(x => Vector3.Distance(x, target.position) > 2)
                .Subscribe(_ => TryAttack(target));
        }
    }
}
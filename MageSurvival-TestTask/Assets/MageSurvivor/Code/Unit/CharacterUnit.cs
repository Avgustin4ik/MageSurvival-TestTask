namespace MageSurvivor.Code.Unit
{
    using Common;
    using Reflex.Attributes;
    using UniRx;
    using UnityEngine;

    public abstract class CharacterUnit : IDamagable
    {
        [Inject] protected DamageEventBus DamageEventBus;
        protected CompositeDisposable Disposables = new CompositeDisposable();
        private readonly float _armor;
        public float Health { get; set; }

        public float Armor { get; protected set; }

        public Vector3 position { get; set; }
        public float Speed { get; set; }
        public float Damage { get; set; }
        public float AttackRange { get; set; }
        public float AttackSpeed { get; set; }

        public ReactiveProperty<bool> IsDead = new ReactiveProperty<bool>(false);

        public void TakeDamage(float damage)
        {
            Health -= damage * Armor;
            if (Health <= 0)
            {
                Die();
            }
        }
        public void Die()
        {
            Debug.Log("Unit Die");
            IsDead.Value = true;
        }
        
        ~CharacterUnit()
        {
            Dispose();
        }
        
        public void Dispose()
        {
            Disposables.Dispose();
        }
    }
}
namespace MageSurvivor.Code.Unit
{
    using UniRx;
    using UnityEngine;

    public abstract class CharacterUnit : IDamageable
    {
        protected CompositeDisposable Disposables = new CompositeDisposable();
        private float _health;
        private readonly float _armor;
        public float Health => _health;
        public float Armor => _armor;
        public Vector3 position { get; set; }
        public ReactiveProperty<bool> IsDead = new ReactiveProperty<bool>(false);

        public void TakeDamage(float damage)
        {
            _health -= damage * Armor;
            if (_health <= 0)
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
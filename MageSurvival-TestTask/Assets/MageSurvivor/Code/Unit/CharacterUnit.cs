namespace MageSurvivor.Code.Unit
{
    using UniRx;
    using UnityEngine;

    public abstract class CharacterUnit : IDamageable
    {
        private float _health;
        private readonly float _armor;
        public float Health => _health;
        public float Armor => _armor;
        public Vector3 position { get; set; }
        public ReactiveProperty<Vector3> postion = new();

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
        }
    }
}
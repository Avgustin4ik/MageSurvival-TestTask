namespace MageSurvivor.Code.Unit
{
    using UnityEngine;

    public abstract class CharacterUnit : IDamageable
    {
        private int _health;
        private readonly int _armor;
        public int Health => _health;
        public int Armor => _armor;
        public Vector3 position { get; set; }

        public void TakeDamage(int damage)
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
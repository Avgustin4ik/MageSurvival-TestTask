namespace MageSurvivor.Code.Unit
{
    using UnityEngine;

    public interface IDamageable
    {
        int Health { get; }
        int Armor { get; }
        Vector3 position { get; set; }
        void TakeDamage(int damage);
        
        void Die();
    }
}
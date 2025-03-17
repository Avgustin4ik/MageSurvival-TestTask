namespace MageSurvivor.Code.Unit
{
    using UnityEngine;

    public interface IDamageable
    {
        float Health { get; }
        float Armor { get; }
        Vector3 position { get; set; }
        void TakeDamage(float damage);
        
        void Die();
    }
}
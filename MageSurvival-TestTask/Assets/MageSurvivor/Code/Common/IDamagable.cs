namespace MageSurvivor.Code.Common
{
    using UnityEngine;

    public interface IDamagable
    {
        float Health { get; }
        float Armor { get; }
        Vector3 position { get; set; }
        void TakeDamage(float damage);
        
        void Die();
    }
}
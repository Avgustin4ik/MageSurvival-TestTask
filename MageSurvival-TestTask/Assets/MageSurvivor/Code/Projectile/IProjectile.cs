namespace MageSurvivor.Code.Projectile
{
    using UnityEngine;

    public interface IProjectile
    {
        public float Damage { get; set; }
        public float Speed { get; set; }
        Vector3 Position { get; }
        void Destroy();
        void Hit(GameObject otherGameObject);
    }
}
namespace MageSurvivor.Code.Common.Projectile
{
    using UnityEngine;

    public interface IProjectile
    {
        Vector3 Position { get; }
        void Destroy();
        void Hit(GameObject otherGameObject);
    }
}
namespace MageSurvivor.Code.Common.Projectile
{
    using UnityEngine;

    public interface IProjectile
    {
        void Launch(Vector3 direction, float speed);
        void UpdatePosition(float deltaTime);
        Vector3 Position { get; }
        void Destroy();
        void Hit(GameObject otherGameObject);
    }
}
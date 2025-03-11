namespace MageSurvivor.Code.Common.Projectile
{
    using UnityEngine;

    public interface IProjectile
    {
        void Launch(Vector3 position);
        void LaunchDirection(Vector3 direction);
        void UpdatePosition(float deltaTime);
        Vector3 Position { get; }
        void Destroy();
        void Hit(GameObject otherGameObject);
    }
}
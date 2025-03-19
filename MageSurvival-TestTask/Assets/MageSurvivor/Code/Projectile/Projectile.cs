namespace MageSurvivor.Code.Projectile
{
    using Common;
    using UnityEngine;

    public class Projectile : IProjectile
    {
        public float Damage { get; set; }
        public float Speed { get; set; }
        public Vector3 Position { get; private set; }
        private Vector3 _direction;
        private float _speed;

        public void Destroy()
        {
        }

        public void Hit(GameObject otherGameObject)
        {
            if(otherGameObject.TryGetComponent(out IDamagable damageable))
            {
                damageable.TakeDamage(Damage);
            }
            throw new System.NotImplementedException($"{this.GetType().Name} hit {otherGameObject.name}");
        }
    }
}
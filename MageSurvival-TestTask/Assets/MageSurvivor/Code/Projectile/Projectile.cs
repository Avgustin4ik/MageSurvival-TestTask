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
        private readonly DamageEventBus _damageEventBus;

        public Projectile(DamageEventBus damageEventBus)
        {
             _damageEventBus = damageEventBus;
        }

        public void Destroy()
        {
        }

        public void Hit(GameObject otherGameObject)
        {
            Debug.Log($"{this.GetType().Name} hit {otherGameObject.name} + {otherGameObject.GetInstanceID()}");
            _damageEventBus.Publish(new DamageEventData(null, otherGameObject, Damage));
        }
    }
}
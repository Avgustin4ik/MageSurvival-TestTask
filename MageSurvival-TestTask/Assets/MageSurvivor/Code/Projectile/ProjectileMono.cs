namespace MageSurvivor.Code.Projectile
{
    using MageSurvivor.Code.Core.Pool;
    using Reflex.Attributes;
    using UnityEngine;

    public class ProjectileMono : PooledMonoBehaviour
    {
        private IProjectile _projectile;
        private Transform _transform;
        private float _speed;

        [Inject]
        public void Construct(IProjectile projectile)
        {
            _projectile = projectile;
            _transform = transform;
        }
        private void Update()
        {
            if(_speed > 0)
                _transform.position += _transform.forward * (_speed * Time.deltaTime);
        }
        private void OnTriggerEnter(Collider other)
        {
            var target = other.gameObject;
            _projectile.Hit(other.gameObject);
        }
        
        private void OnBecameInvisible()
        {
            _projectile.Destroy();
            this.Release();
        }

        public void LaunchForward(float dataSpeed)
        {
            _speed = dataSpeed;
        }

        public void SetData(DamageProjectileData data)
        {
            _projectile.Damage = data.Damage;
            _speed = data.Speed;
        }
    }
}
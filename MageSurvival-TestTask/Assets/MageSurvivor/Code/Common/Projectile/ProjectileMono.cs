namespace MageSurvivor.Code.Common.Projectile
{
    using System;
    using Core.Pool;
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
        
        //я хочу разделить логику отображения и логику движения
        private void Update()
        {
            if(_speed > 0)
                _transform.position += _transform.forward * (_speed * Time.deltaTime);
        }


        private void OnCollisionEnter(Collision other)
        {
            _projectile.Hit(other.gameObject);
        }
        
        private void OnTriggerEnter(Collider other)
        {
            
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

        
    }
}
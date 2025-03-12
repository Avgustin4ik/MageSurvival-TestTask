namespace MageSurvivor.Code.Common.Projectile
{
    using Reflex.Attributes;
    using UnityEngine;

    public class ProjectileMono : MonoBehaviour
    {
        private IProjectile _projectile;
        private Transform _transform;
        [Inject]
        public void Construct(IProjectile projectile)
        {
            _projectile = projectile;
            _transform = transform;
        }
        //я хочу разделить логику отображения и логику движения
        private void Update()
        {
            _projectile.UpdatePosition(Time.deltaTime);
            _transform.position = _projectile.Position;
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
        }

        public void Lunch(Vector3 transformForward, float dataSpeed) => _projectile.Launch(transformForward,dataSpeed);
    }
    
    public class PoolableMono : MonoBehaviour
    {
        
    }
}
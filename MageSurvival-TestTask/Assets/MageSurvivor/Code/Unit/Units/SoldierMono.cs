namespace MageSurvivor.Code.Unit.Units
{
    using Code.Player;
    using Reflex.Attributes;
    using UnityEngine;
    using UnityEngine.AI;

    public class SoldierMono : MonoBehaviour
    {
        public NavMeshAgent agent;
        private Enemy _enemy;
        private IPlayer _target;
        private Transform _cachedTransform;

        [Inject]
        public void Construct(Enemy enemy, IPlayer target)
        {
            _enemy = enemy;
            _target = target;
            _cachedTransform = transform;
            enemy.SetTarget(target);
        }
        
        public void Update()
        {
            if (_enemy == null) return;
            
            MoveToEnemy(_target.position);
            _enemy.SetPosition(_cachedTransform.position);
        }
        
        public void MoveToEnemy(Vector3 enemy)
        {
            agent.SetDestination(enemy);
        }
    }
}
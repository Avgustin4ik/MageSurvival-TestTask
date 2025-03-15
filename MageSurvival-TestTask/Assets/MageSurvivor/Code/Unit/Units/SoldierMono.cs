namespace MageSurvivor.Code.Unit.Units
{
    using Code.Player;
    using Cysharp.Threading.Tasks;
    using Reflex.Attributes;
    using UnitFactory;
    using UnitFactory.Abstract;
    using UnityEngine;
    using UnityEngine.AI;

    public class SoldierMono : MonoBehaviour
    {
        public NavMeshAgent agent;
        private SoldierUnit _enemy;
        private IPlayer _target;
        private Transform _cachedTransform;

        [Inject]
        public void Construct(SoldierUnit soldierUnit, IPlayer target)
        {
            _enemy = soldierUnit;
            _target = target;
            _cachedTransform = transform;
            Setup(soldierUnit.Config);
            // soldierUnit.SetTarget(target);
        }

        private async UniTaskVoid Setup(Config soldierUnitConfig)
        {
            agent.speed = soldierUnitConfig.MoveSpeed;
            //setup visual and monobeheviour
        }

        public void Update()
        {
            if (_enemy == null) return;
            
            MoveToEnemy(_target.position);
            // _enemy.SetPosition(_cachedTransform.position);
        }
        
        public void MoveToEnemy(Vector3 enemy)
        {
            agent.SetDestination(enemy);
        }
    }
}
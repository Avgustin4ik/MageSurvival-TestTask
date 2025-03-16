namespace MageSurvivor.Code.Unit.Units
{
    using System;
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
        private SoldierUnit _unitBrain;
        private IPlayer _target;
        private Transform _cachedTransform;

        [Inject]
        public void Construct(SoldierUnit soldierUnit, IPlayer target)
        {
            _unitBrain = soldierUnit;
            _target = target;
            _cachedTransform = transform;
            Setup(soldierUnit.Config);
            soldierUnit.SetTarget(target);
        }

        private async UniTaskVoid Setup(Config soldierUnitConfig)
        {
            agent.speed = soldierUnitConfig.MoveSpeed;
            //setup visual and monobeheviour
        }

        public void Update()
        {
            if (_unitBrain == null) return;
            
            MoveToEnemy(_target.position);
            _unitBrain.position = _cachedTransform.position;
        }
        
        public void MoveToEnemy(Vector3 enemy)
        {
            agent.SetDestination(enemy);
        }

#if UNITY_EDITOR
        private void OnDrawGizmos()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawLine(_unitBrain.position, _target.position);

            float distance = Vector3.Distance(_unitBrain.position, _target.position);
            Vector3 labelPosition = _unitBrain.position + Vector3.up * 2; // Adjust the height as needed
            GUIStyle style = new GUIStyle();
            style.normal.textColor = Color.white;
            UnityEditor.Handles.Label(labelPosition, $"Distance: {distance:F2}", style);
            Gizmos.color = Color.white;
        }
#endif


        private void OnDestroy()
        {
            _unitBrain?.Dispose();
        }
    }
}
namespace MageSurvivor.Code.Unit.Units
{
    using Code.Player;
    using Reflex.Attributes;
    using UnitFactory;
    using UnityEngine;
    using UnityEngine.AI;

    public class SoldierMono : CharacterMono
    {
        public NavMeshAgent agent;
        private IPlayer _target;

        [Inject]
        public void Construct(SoldierUnit soldierUnit, IPlayer target)
        {
            Initialize(soldierUnit);
            _target = target;
            soldierUnit.SetTarget(target);
        }
        
        private void Die(bool isDead)
        {
            if (isDead)
            {
                Destroy(gameObject);
            }
        }

        

        public void Update()
        {
            if (base.Character == null) return;
            MoveToEnemy(_target.position);
            this.Character.position = this.CachedTransform.position;
        }
        
        public void MoveToEnemy(Vector3 enemy)
        {
            agent.SetDestination(enemy);
        }

#if UNITY_EDITOR
        private void OnDrawGizmos()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawLine(Character.position, _target.position);

            float distance = Vector3.Distance(Character.position, _target.position);
            Vector3 labelPosition = Character.position + Vector3.up * 2; // Adjust the height as needed
            GUIStyle style = new GUIStyle();
            style.normal.textColor = Color.white;
            UnityEditor.Handles.Label(labelPosition, $"Distance: {distance:F2}", style);
            Gizmos.color = Color.white;
        }
#endif


        private void OnDestroy()
        {
            Character?.Dispose();
        }
        
        
    }
}
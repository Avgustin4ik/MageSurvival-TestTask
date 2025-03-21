namespace MageSurvivor.Code.Unit.Units
{
    using Common;
    using Player;
    using Reflex.Attributes;
    using UnitFactory;
    using UnitFactory.Abstract;
    using UnityEngine;
    using UnityEngine.AI;

    public abstract class SoldierMono : CharacterMono
    {
        public NavMeshAgent agent;
        private CharacterUnitBase _target;
        public static int count = 0;
        
        [Inject]
        public void Construct(AttackerUnit soldierUnit, DamageEventBus damageEventBus, Player target)
        {
            base.Construct(soldierUnit, damageEventBus);
            _target = target;
            soldierUnit.SetTarget(_target);
            agent.speed = soldierUnit.Config.MoveSpeed;
            count++;
        }
        
        protected override void Update()
        {
            if (base.Character == null) return;
            if(_target == null) return;
            MoveToEnemy(_target.position);
            base.Update();
        }
        
        public void MoveToEnemy(Vector3 enemy)
        {
            agent.SetDestination(enemy);
        }

#if UNITY_EDITOR
        private void OnDrawGizmos()
        {
            if (Character == null || _target == null) return;
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
            count--;
            base.OnDestroy();
        }
    }
}
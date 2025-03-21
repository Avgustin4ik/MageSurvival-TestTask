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
        public static int count = 0;
        [Inject] public Player _targetPlayer;
        
        protected void Construct(AttackerUnit unit)
        {
            base.Construct(unit);
            unit.SetTarget(_targetPlayer);
            agent.speed = unit.Config.MoveSpeed;
            Debug.Log("SoldierMono Construct. Speed: " + agent.speed);
            count++;
        }
        
        protected override void Update()
        {
            if (base.Character == null) return;
            if(_targetPlayer == null) return;
            MoveToEnemy(_targetPlayer.position);
            base.Update();
        }
        
        public void MoveToEnemy(Vector3 enemy)
        {
            agent.SetDestination(enemy);
        }

#if UNITY_EDITOR
        private void OnDrawGizmos()
        {
            if (Character == null || _targetPlayer == null) return;
            Gizmos.color = Color.red;
            Gizmos.DrawLine(Character.position, _targetPlayer.position);

            float distance = Vector3.Distance(Character.position, _targetPlayer.position);
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
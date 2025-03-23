namespace MageSurvivor.Code.Unit.Units
{
    using System;
    using Common;
    using Reflex.Attributes;
    using UniRx;
    using UnitFactory.Abstract;
    using UnityEngine;

    public abstract class CharacterMono : MonoBehaviour
    {
        protected Transform CachedTransform;
        protected CharacterUnitBase Character;
        protected bool Initialized;
        [Inject] protected DamageEventBus _eventBus;

        protected void Construct(CharacterUnitBase character)
        {
            Character = character;
            _eventBus.OnDamageEvent += DealDamage;
            character.IsDead.Subscribe(Kill).AddTo(this);
            Initialize();
        }

        protected void Initialize()
        {
            Character.position = transform.position;
            CachedTransform = transform;
            Setup(Character.Config);
            Initialized = true;
        }
        
        public virtual void Kill(bool isDead)
        {
            if (isDead)
            {
                Destroy(gameObject);
                Character?.Dispose();
            }
        }
        
        private void DealDamage(DamageEventData obj)
        {
            if(obj.Target == null) return;
            if (obj.Target != gameObject) return;
            Character.TakeDamage(obj.Damage);
        }

        public virtual void Setup(Config config) => Character.SetConfig(config);

        protected virtual void Update()
        {
            Character.position = CachedTransform.position;
        }

        protected virtual void OnDestroy()
        {
            Debug.Log("CharacterMono OnDestroy");
            if(_eventBus != null)
                _eventBus.OnDamageEvent -= DealDamage;
            Character?.Dispose();
        }

#if UNITY_EDITOR
        private void OnDrawGizmos()
        {
            if (Character == null) return;
            Vector3 labelPosition = Character.position + Vector3.up * 2; // Adjust the height as needed
            GUIStyle style = new GUIStyle();
            style.normal.textColor = Color.white;
            UnityEditor.Handles.Label(labelPosition, $"HP: {Character.Health:F2}", style);
        }
#endif
    }
}
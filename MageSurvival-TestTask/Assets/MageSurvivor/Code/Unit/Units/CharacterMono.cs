namespace MageSurvivor.Code.Unit.Units
{
    using System;
    using Common;
    using Reflex.Attributes;
    using UniRx;
    using UnitFactory.Abstract;
    using UnityEngine;
    using Object = System.Object;

    public abstract class CharacterMono : MonoBehaviour
    {
        protected Transform CachedTransform;
        public CharacterUnitBase Character;
        protected bool Initialized;
        private DamageEventBus _eventBus;

        public virtual void Initialize(CharacterUnitBase character, DamageEventBus damageEventBus)
        {
            _eventBus = damageEventBus;
            Character = character;
            Character.position = transform.position;
            CachedTransform = transform;
            
            Setup(Character.Config);
            character.IsDead.Subscribe(Kill).AddTo(this);
            Initialized = true;
            _eventBus.OnDamageEvent += DealDamage;
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

        public virtual void Setup(Config config)
        {
            Character.SetConfig(config);
        }

        protected virtual void Update()
        {
            Character.position = CachedTransform.position;
        }

        protected virtual void OnDestroy()
        {
            Debug.Log("CharacterMono OnDestroy");
            _eventBus.OnDamageEvent -= DealDamage;
            Character?.Dispose();
        }
    }
}
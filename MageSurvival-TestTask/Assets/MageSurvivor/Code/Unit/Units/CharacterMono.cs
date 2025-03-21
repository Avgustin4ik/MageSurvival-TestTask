namespace MageSurvivor.Code.Unit.Units
{
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
        private DamageEventBus _eventBus;

        [Inject]
        public void Construct(CharacterUnitBase character, DamageEventBus damageEventBus)
        {
            Character = character;
            _eventBus = damageEventBus;
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
    }
}
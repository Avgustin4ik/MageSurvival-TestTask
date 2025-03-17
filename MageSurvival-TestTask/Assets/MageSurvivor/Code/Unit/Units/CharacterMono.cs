namespace MageSurvivor.Code.Unit.Units
{
    using System;
    using Reflex.Attributes;
    using UniRx;
    using UnitFactory.Abstract;
    using UnityEngine;

    public abstract class CharacterMono : MonoBehaviour
    {
        protected Transform CachedTransform;
        protected CharacterUnitBase Character;
        protected bool Initialized;
        
        public virtual void Initialize(CharacterUnitBase character)
        {
            Character = character;
            Character.position = transform.position;
            CachedTransform = transform;
            
            Setup(Character.Config);
            character.IsDead.Subscribe(Kill).AddTo(this);
            Initialized = true;
        }

        public virtual void Kill(bool isDead)
        {
            if (isDead)
            {
                Destroy(gameObject);
            }
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
            Character?.Dispose();
        }
    }
}
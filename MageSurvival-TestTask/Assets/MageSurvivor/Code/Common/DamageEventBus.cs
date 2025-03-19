namespace MageSurvivor.Code.Common
{
    using System;
    using UnityEngine;

    public class DamageEventData
    {
        public GameObject Source { get; private set; }
        public GameObject Target { get; private set; }
        public float Damage { get; private set; }
        
        public DamageEventData(GameObject source, GameObject target, float damage)
        {
            Source = source;
            Target = target;
            Damage = damage;
        }
    }
    
    public class DamageEventBus
    {
        public event Action<DamageEventData> OnDamageEvent;
        public void Publish(DamageEventData damageEventData)
        {
            OnDamageEvent?.Invoke(damageEventData);
        }
        
        public void Subscribe(Action<DamageEventData> action)
        {
            OnDamageEvent += action;
        }
        
        public void Unsubscribe(Action<DamageEventData> action)
        {
            OnDamageEvent -= action;
        }
        
        public void Clear()
        {
            OnDamageEvent = null;
        }
    }
}
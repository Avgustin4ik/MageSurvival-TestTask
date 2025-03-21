namespace MageSurvivor.Code.Unit.Units
{
    using Common;
    using Player;
    using Reflex.Attributes;
    using UnityEngine;

    public class DefaultUnitMono : SoldierMono
    {
        [Inject]
        public void Construct(DefaultUnit defaultUnit, DamageEventBus damageEventBus, Player player)
        {
            base.Construct(defaultUnit, damageEventBus);
            Debug.Log("DefaultUnitMono Construct");
        }
    }
}
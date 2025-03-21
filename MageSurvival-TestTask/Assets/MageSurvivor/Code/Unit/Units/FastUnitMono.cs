namespace MageSurvivor.Code.Unit.Units
{
    using Common;
    using Player;
    using Reflex.Attributes;
    using UnitFactory;
    using UnityEngine;

    public class FastUnitMono : SoldierMono
    {
        [Inject]
        public void Construct(FastUnit fastUnit)
        {
            base.Construct(fastUnit);
            Debug.Log("FastUnitMono Construct");
        }
    }
}
namespace MageSurvivor.Code.Unit.Units
{
    using Common;
    using Reflex.Attributes;
    using UnitFactory;
    using UnityEngine;

    public class BigUnitMono : SoldierMono
    {
        [Inject]
        public void Construct(BigUnit bigUnit)
        {
            base.Construct(bigUnit);
            Debug.Log("BigUnitMono Construct");
        }
    }
}
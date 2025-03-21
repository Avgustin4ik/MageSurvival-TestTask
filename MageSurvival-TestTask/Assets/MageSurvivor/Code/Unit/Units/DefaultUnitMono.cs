namespace MageSurvivor.Code.Unit.Units
{
    using Common;
    using Player;
    using Reflex.Attributes;
    using UnityEngine;

    public class DefaultUnitMono : SoldierMono
    {
        [Inject]
        public void Construct(DefaultUnit defaultUnit)
        {
            base.Construct(defaultUnit);
            Debug.Log("DefaultUnitMono Construct");
        }
    }
}
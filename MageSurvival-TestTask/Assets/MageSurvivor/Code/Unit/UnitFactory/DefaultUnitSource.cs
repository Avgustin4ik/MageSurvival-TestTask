namespace MageSurvivor.Code.Unit.UnitFactory
{
    using Abstract;
    using Units;
    using UnityEngine;

    [CreateAssetMenu(menuName = "Sources/Uint/DefaultUnitSource", fileName = "DefaultUnitSource")]
    public class DefaultUnitSource : CharacterUnitSource<DefaultUnit>
    {
    }
}
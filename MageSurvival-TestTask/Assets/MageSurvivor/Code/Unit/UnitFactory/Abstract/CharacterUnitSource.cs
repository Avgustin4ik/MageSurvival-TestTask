namespace MageSurvivor.Code.Unit.UnitFactory.Abstract
{
    using UnityEngine;

    public abstract class CharacterUnitSource<T> : ScriptableObject where T : ICharacterUnit, new()
    {
        public Config Config;
        public T CreateUnit()
        {
            var unit = new T();
            unit.SetConfig(Config);
            return unit;
        }
    }
}
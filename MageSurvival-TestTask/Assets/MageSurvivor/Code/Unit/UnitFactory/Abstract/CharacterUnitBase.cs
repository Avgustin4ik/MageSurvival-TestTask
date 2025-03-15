namespace MageSurvivor.Code.Unit.UnitFactory.Abstract
{
    using UnityEngine;

    public class CharacterUnitBase : CharacterUnit, ICharacterUnit
    {
        public Config Config { get; private set;}
        public virtual void SetConfig(Config config)
        {
            Config = config;
        }
        
        public void SetPosition(Vector3 position)
        {
            position = position;
        }
    }
}
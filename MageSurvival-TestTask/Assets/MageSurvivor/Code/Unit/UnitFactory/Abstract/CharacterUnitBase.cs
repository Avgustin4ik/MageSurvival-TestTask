namespace MageSurvivor.Code.Unit.UnitFactory.Abstract
{
    using UniRx;
    using UnityEngine;

    public abstract class CharacterUnitBase : CharacterUnit, ICharacterUnit
    {
        public Config Config { get; private set;}
        public virtual void SetConfig(Config config)
        {
            Config = config;
        }
        
    }
}
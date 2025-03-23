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
            base.Health = config.Health;
            base.Armor = config.Armor;
            base.Speed = config.MoveSpeed;
            base.Damage = config.Damage;
            base.AttackRange = config.AttackRange;
            base.AttackSpeed = config.AttackSpeed;

        }
        
    }
}
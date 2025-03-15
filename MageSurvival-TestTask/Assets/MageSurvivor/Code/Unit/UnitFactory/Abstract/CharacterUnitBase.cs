namespace MageSurvivor.Code.Unit.UnitFactory.Abstract
{
    public class CharacterUnitBase : ICharacterUnit
    {
        public Config Config { get; private set;}
        public void SetConfig(Config config)
        {
            Config = config;
        }
    }
}
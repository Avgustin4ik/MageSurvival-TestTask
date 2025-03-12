namespace MageSurvivor.Code.Services.AbilityService
{
    using Abilities.Abstract;

    public interface IAbilityService
    {
        public IAbility CreateAbility(string abilityType);
    }
}
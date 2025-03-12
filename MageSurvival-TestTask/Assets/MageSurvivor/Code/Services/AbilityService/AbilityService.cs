namespace MageSurvivor.Code.Services.AbilityService
{
    using System.Collections.Generic;
    using Abilities.Abstract;
    using Core.Abstract.Service;
    using UnityEngine;

    public class AbilityService : Service, IAbilityService
    {
        private readonly Dictionary<string, AbilitySource> _abilitySourceDictionary;
        public AbilityService(AbilitySource[] abilitySources)
        {
            _abilitySourceDictionary = new Dictionary<string, AbilitySource>();
            foreach (var abilitySource in abilitySources)
            {
                _abilitySourceDictionary.Add(abilitySource.AbilityType,abilitySource);
            }
        }
        
        public IAbility CreateAbility(string abilityType)
        {
            if (_abilitySourceDictionary.TryGetValue(abilityType, out var abilitySource))
            {
                return abilitySource.CreateAbility();
            }
            Debug.LogError("Ability type not found: " + abilityType);
            return null;
        }
    }
}
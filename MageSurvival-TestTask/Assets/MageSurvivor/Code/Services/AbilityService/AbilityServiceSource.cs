namespace MageSurvivor.Code.Services.AbilityService
{
    using System;
    using Abilities.Abstract;
    using Core.Abstract.Service;
    using UnityEngine;

    [CreateAssetMenu(fileName = "AbilityServiceSource", menuName = "MageSurvivor/Services/AbilityServiceSource")]
    public class AbilityServiceSource : ServiceSource<AbilityService>
    {
        public AbilitySource[] AbilitySources; 
        protected override AbilityService CreateServiceInstance()
        {
            return new AbilityService(AbilitySources);
        }
    }
}
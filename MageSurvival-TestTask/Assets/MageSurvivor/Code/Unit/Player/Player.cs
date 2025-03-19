namespace MageSurvivor.Code.Unit.Player
{
    using MageSurvivor.Code.Abilities;
    using MageSurvivor.Code.Abilities.Abstract;
    using MageSurvivor.Code.Services.AbilityService;
    using UnitFactory.Abstract;
    using UnityEngine;

    public class Player : CharacterUnitBase, IPlayer
    {
        private readonly IAbilityService _abilityService;
        public void EquipAbility(IAbility ability)
        {
            Abilities.Add(ability);
        }

        public AbilityPool Abilities { get; private set; }

        public Player(IAbilityService abilityService)
        {
            Abilities = new AbilityPool();
            _abilityService = abilityService;
            EquipAbility(abilityService.CreateAbility(nameof(FireballAbility)));
            EquipAbility(abilityService.CreateAbility(nameof(IceBoltAbility)));
            EquipAbility(abilityService.CreateAbility(nameof(LightningBoltAbility)));
        }
        ~Player()
        {
            Debug.Log("Player Destructor");
        }

        public void SelectAbility(int index) => Abilities.SelectAbility(index);
        public void UseAbility(GameObject caster, GameObject target)
        {
            throw new System.NotImplementedException();
        }
        public void UseAbility(GameObject caster, Vector3 direction) => Abilities.UseSelectedAbility(caster, direction);

        public int Health { get; }
        public int Armor { get; }
        public Vector3 position { get; set; }

        public void Die()
        {
            throw new System.NotImplementedException();
        }

        public void UseAbility<T>(GameObject target) where T : IAbility
        {
            throw new System.NotImplementedException();
        }

        public void UseAbility(IAbility ability, GameObject target)
        {
            throw new System.NotImplementedException();
        }
    }
}
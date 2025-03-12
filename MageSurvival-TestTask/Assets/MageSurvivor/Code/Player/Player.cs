namespace MageSurvivor.Code.Player
{
    using Abilities;
    using Abilities.Abstract;
    using Services.AbilityService;
    using UnityEngine;

    public class Player : IPlayer
    {
        private readonly IAbilityService _abilityService;
        private IPlayer _playerImplementation;
        public void EquipAbility(IAbility ability) => Abilities.Add(ability);

        public AbilityPool Abilities { get; }

        // public Player(IAbilityService abilityService)
        // {
        //     _abilityService = abilityService;
        //     // EquipAbility(abilityService.CreateAbility(nameof(FireballAbility)));
        // }

        public Player()
        {
        }


        //где-то происходит еквип аблок для юнита. Предположим что это происходит в Awake
        public void Awake()
        {
            EquipAbility(_abilityService.CreateAbility(nameof(FireballAbility)));
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

        public void TakeDamage(int damage)
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
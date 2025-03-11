namespace MageSurvivor.Code.Player
{
    using Abilities;
    using Abilities.Abstract;
    using Services.InputService;
    using UnityEngine;

    public class Player : IPlayer
    {
        private readonly IInputService _inputService;
        private IPlayer _playerImplementation;
        public AbilityPool Abilities { get; }

        public Player(IInputService inputService)
        {
            _inputService = inputService;
            Abilities = new AbilityPool();
            BindControls(inputService);
        }

        private void BindControls(IInputService inputService)
        {
            inputService.SelectNextAbility += Abilities.GetNextAbility;
            inputService.SelectPreviousAbility += Abilities.GetPreviousAbility;
            inputService.UseSelectedAbility += () => Abilities.UseSelectedAbility(null, null);
        }
        
        ~Player()
        {
            Debug.Log("Player Destructor");
            _inputService.SelectNextAbility -= Abilities.GetNextAbility;
            _inputService.SelectPreviousAbility -= Abilities.GetPreviousAbility;
            _inputService.UseSelectedAbility -= () => Abilities.UseSelectedAbility(null, null);
        }

        public void SelectAbility(int index) => Abilities.SelectAbility(index);
        public void UseAbility(GameObject caster, GameObject target) => Abilities.UseSelectedAbility(caster, target);

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
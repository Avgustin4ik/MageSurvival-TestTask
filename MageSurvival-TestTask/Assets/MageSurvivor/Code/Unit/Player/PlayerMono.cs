namespace MageSurvivor.Code.Unit.Player
{
    using MageSurvivor.Code.Services.InputService;
    using Reflex.Attributes;
    using UniRx;
    using UnitFactory.Abstract;
    using Units;
    using UnityEngine;

    public class PlayerMono : CharacterMono
    {
        private IInputService _inputService;
        private Player _player;

        [Inject]
        public void Construct(CharacterUnitBase player, IInputService inputService)
        {
            base.Initialize(player);
            _player = player as Player;
            _inputService = inputService;
            BindControls();
            Debug.Log("PlayerMono Construct");
            player.IsDead.Subscribe(Die).AddTo(this);
        }
        
        private void Die(bool isDead)
        {
            if (isDead)
            {
                //animate death
                Destroy(gameObject);
            }
        }

        private void BindControls()
        {
            _inputService.SelectNextAbility += _player.Abilities.GetNextAbility;
            _inputService.SelectPreviousAbility += _player.Abilities.GetPreviousAbility;
            _inputService.UseSelectedAbility += Use;
        }

        private void Use()
        {
            _player.Abilities.UseSelectedAbility(this.gameObject, this.transform.forward);
        }

        protected override void OnDestroy()
        {
            _inputService.SelectNextAbility -= _player.Abilities.GetNextAbility;
            _inputService.SelectPreviousAbility -= _player.Abilities.GetPreviousAbility;
            _inputService.UseSelectedAbility -= Use;
            base.OnDestroy();
        }
    }
}
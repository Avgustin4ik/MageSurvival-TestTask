namespace MageSurvivor.Code.Player
{
    using System;
    using Reflex.Attributes;
    using Services.InputService;
    using UnityEngine;

    public class PlayerMono : MonoBehaviour
    {
        private IPlayer _player;
        public CharacterController characterController;
        private IInputService _inputService;

        [Inject]
        public void Construct(IPlayer player, IInputService inputService)
        {
            _player = player;
            _inputService = inputService;
            BindControls();
            Debug.Log("PlayerMono Construct");
        }

        // [Inject]
        // public void Construct(IPlayer p, IInputService inputService)
        // {
        //     _player = p;
        //     _inputService = inputService;
        //     Debug.Log("PlayerMono Construct");
        //
        // }

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

        private void OnDestroy()
        {
            _inputService.SelectNextAbility -= _player.Abilities.GetNextAbility;
            _inputService.SelectPreviousAbility -= _player.Abilities.GetPreviousAbility;
            _inputService.UseSelectedAbility -= Use;
        }
    }
}
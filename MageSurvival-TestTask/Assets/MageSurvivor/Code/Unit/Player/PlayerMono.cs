namespace MageSurvivor.Code.Unit.Player
{
    using Code.Player;
    using MageSurvivor.Code.Services.InputService;
    using Reflex.Attributes;
    using Reflex.Enums;
    using UnityEngine;

    public class PlayerMono : MonoBehaviour
    {
        private IPlayer _player;
        public CharacterController characterController;
        private IInputService _inputService;
        private Transform _cachedTransform;

        [Inject]
        public void Construct(IPlayer player, IInputService inputService)
        {
            _player = player;
            _inputService = inputService;
            _cachedTransform = transform;
            BindControls();
            Debug.Log("PlayerMono Construct");
        }

        private void Update()
        {
            _player.position = _cachedTransform.position;
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

        private void OnDestroy()
        {
            _inputService.SelectNextAbility -= _player.Abilities.GetNextAbility;
            _inputService.SelectPreviousAbility -= _player.Abilities.GetPreviousAbility;
            _inputService.UseSelectedAbility -= Use;
        }
    }
}
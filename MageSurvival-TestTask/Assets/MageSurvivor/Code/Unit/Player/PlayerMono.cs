namespace MageSurvivor.Code.Unit.Player
{
    using MageSurvivor.Code.Services.InputService;
    using Reflex.Attributes;
    using Units;
    using UnityEngine;

    public class PlayerMono : CharacterMono
    {
        public CharacterController _characterController;
        [Inject] private IInputService _inputService;
        private Player _player;
        private Vector2 _movementDirection = Vector2.zero;
        
        [Inject]    
        public void Construct(Player player)
        {
            _player = player;
            base.Construct(player);
            BindControls();
            Debug.Log("PlayerMono Construct");
        }
        
        private void BindControls()
        {
            _inputService.Move += SetDirection;
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
        
        protected override void Update()
        {
            base.Update();
            Move(_movementDirection.y);
            Rotate(_movementDirection.x);
        }

        private void Move(float y)
        {
            if(y == 0) return;
            _characterController.Move((y > 0 ? CachedTransform.forward : -CachedTransform.forward) *
                                      (1 * Time.deltaTime * _player.Config.MoveSpeed));
        }

        private void Rotate(float rotationAroundY)
        {
            if(rotationAroundY == 0) return;
            this.CachedTransform.Rotate(Vector3.up, rotationAroundY *_player.Config.RotationSpeed * Time.deltaTime );
        }

        private void SetDirection(Vector2 axis)
        {
            _movementDirection = axis;
        }
    }
}
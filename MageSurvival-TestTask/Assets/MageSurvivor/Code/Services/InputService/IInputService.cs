namespace MageSurvivor.Code.Services.InputService
{
    using System;
    using Core.Abstract.Service;
    using UniRx;
    using UnityEngine;
    using UnityEngine.InputSystem;

    public interface IInputService
    {
        event System.Action<Vector2> Move;
        event System.Action SelectNextAbility;
        event System.Action SelectPreviousAbility;
        event System.Action UseSelectedAbility;
    }
    
    public class InputService : Service, IInputService
    {
        private readonly KeyBinding _keyBinding;

        public InputService(KeyBinding keyBinding)
        {
            _keyBinding = keyBinding;
            BindControls();
        }

        private void BindControls()
        {
            _keyBinding.Move.action.canceled += ctx => OnMove(Vector2.zero);
            _keyBinding.Move.action.performed += ctx => OnMove(ctx.ReadValue<Vector2>());
            _keyBinding.NextAbilityAction.action.performed += _ => OnSelectNextAbility();
            _keyBinding.PreviousAbilityAction.action.performed += _ => OnSelectPreviousAbility();
            _keyBinding.UseAbilityAction.action.performed += _ => OnUseSelectedAbility();
        }
        
        ~InputService()
        {
            Debug.Log("InputService Destructor");

            _keyBinding.NextAbilityAction.action.performed -= _ => OnSelectNextAbility();
            _keyBinding.PreviousAbilityAction.action.performed -= _ => OnSelectPreviousAbility();
            _keyBinding.UseAbilityAction.action.performed -= _ => OnUseSelectedAbility();
            _keyBinding.Move.action.canceled-= ctx => OnMove(Vector2.zero);
            _keyBinding.Move.action.performed -= ctx => OnMove(ctx.ReadValue<Vector2>());
        }

        public event Action<Vector2> Move;
        public event System.Action SelectNextAbility;
        public event System.Action SelectPreviousAbility;
        public event System.Action UseSelectedAbility;

        private void OnSelectNextAbility() => SelectNextAbility?.Invoke();
        private void OnSelectPreviousAbility() => SelectPreviousAbility?.Invoke();
        private void OnUseSelectedAbility() => UseSelectedAbility?.Invoke();
        private void OnMove(Vector2 direction) => Move?.Invoke(direction);
    }

    [Serializable]
    public struct KeyBinding
    {
        public InputActionReference NextAbilityAction;
        public InputActionReference PreviousAbilityAction;
        public InputActionReference UseAbilityAction;
        public InputActionReference Move;
    }
    
}
namespace MageSurvivor.Code.Services.InputService
{
    using System;
    using Core.Abstract.Service;
    using UniRx;
    using UnityEngine;
    using UnityEngine.InputSystem;

    public interface IInputService
    {
        event System.Action SelectNextAbility;
        event System.Action SelectPreviousAbility;
        event System.Action UseSelectedAbility;
    }
    
    public class InputService : Service, IInputService
    {
        private readonly KeyBinding _keyBinding;
        private IDisposable _nextStream;
        private IDisposable _previousStream;
        private IDisposable _useStream;

        public InputService(KeyBinding keyBinding)
        {
            _keyBinding = keyBinding;
            BindControls();
        }

        private void BindControls()
        {
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
        }

        public event System.Action SelectNextAbility;
        public event System.Action SelectPreviousAbility;
        public event System.Action UseSelectedAbility;

        private void OnSelectNextAbility() => SelectNextAbility?.Invoke();
        private void OnSelectPreviousAbility() => SelectPreviousAbility?.Invoke();
        private void OnUseSelectedAbility() => UseSelectedAbility?.Invoke();
        
        
    }

    [Serializable]
    public struct KeyBinding
    {
        public InputActionReference NextAbilityAction;
        public InputActionReference PreviousAbilityAction;
        public InputActionReference UseAbilityAction;
    }
    
}
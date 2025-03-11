namespace MageSurvivor.Code.Services.InputService
{
    using Core.Abstract.Service;
    using UnityEngine;

    [CreateAssetMenu(menuName = "ServiceSource/InputService")]
    public class InputServiceSource : ServiceSource<InputService>
    {
        public KeyBinding KeyBinding;
        protected override InputService CreateServiceInstance()
        {
            return new InputService(KeyBinding);
        }
    }
}
namespace MageSurvivor.Code.Services.InputService
{
    using Core.Abstract.Service;
    using UnityEngine;
    
    [CreateAssetMenu(fileName = "InputServiceSource", menuName = "MageSurvivor/Services/InputServiceSource")]
    public class InputServiceSource : ServiceSource<InputService>
    {
        public KeyBinding KeyBinding;
        protected override InputService CreateServiceInstance()
        {
            return new InputService(KeyBinding);
        }
    }
}
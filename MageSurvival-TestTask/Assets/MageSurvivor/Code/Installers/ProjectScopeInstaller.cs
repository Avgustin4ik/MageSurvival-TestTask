namespace MageSurvivor.Code.Installers
{
    using Common;
    using Reflex.Core;
    using UnityEngine;

    public class ProjectScopeInstaller : MonoBehaviour, IInstaller
    {
        public void InstallBindings(ContainerBuilder containerBuilder)
        {
            containerBuilder.AddSingleton(typeof(DamageEventBus));
        }
    }
}
namespace MageSurvivor.Code.Installers
{
    using global::Code.Core;
    using global::Code.Core.Factories;
    using Player;
    using Reflex.Core;
    using Unit;
    using Unit.Player;
    using UnityEngine;

    public class GameplayInstaller : MonoBehaviour, IInstaller
    {
        public Transform playerTransform;
        public void InstallBindings(ContainerBuilder containerBuilder)
        {
            containerBuilder.AddSingleton(typeof(Injector));
            containerBuilder.AddSingleton(typeof(PropsFactory));
            
            containerBuilder.AddSingleton(typeof(Player), typeof(IPlayer));
            containerBuilder.AddSingleton(playerTransform, typeof(Transform));
            containerBuilder.AddSingleton(typeof(Enemy));
            Debug.Log("GameplayInstaller InstallBindings");
        }
    }
}
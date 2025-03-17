namespace MageSurvivor.Code.Installers
{
    using global::Code.Core;
    using global::Code.Core.Factories;
    using Player;
    using Reflex.Core;
    using Unit.Player;
    using Unit.UnitFactory;
    using Unit.UnitFactory.Abstract;
    using UnityEngine;

    public class GameplayInstaller : MonoBehaviour, IInstaller
    {
        public Transform playerTransform;
        public SoldierUnitSource soldierUnitSource;
        public void InstallBindings(ContainerBuilder containerBuilder)
        {
            containerBuilder.AddSingleton(typeof(Injector));
            containerBuilder.AddSingleton(typeof(PropsFactory));

            containerBuilder.AddSingleton(typeof(Player), typeof(CharacterUnitBase));
            containerBuilder.AddSingleton(playerTransform, typeof(Transform));
            containerBuilder.AddTransient(_ =>soldierUnitSource.CreateUnit());
            Debug.Log("GameplayInstaller InstallBindings");
        }
    }
}
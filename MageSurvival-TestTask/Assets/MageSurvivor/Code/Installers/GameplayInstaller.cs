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
            
            // containerBuilder.AddTransient(typeof(CharacterUnitBase), typeof(ICharacterUnit));
            containerBuilder.AddSingleton(typeof(Player), typeof(IPlayer));
            containerBuilder.AddSingleton(playerTransform, typeof(Transform));
            containerBuilder.AddTransient(_ =>soldierUnitSource.CreateUnit());
            // containerBuilder.AddSingleton(typeof(Enemy));
            Debug.Log("GameplayInstaller InstallBindings");
        }
    }
}
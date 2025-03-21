namespace MageSurvivor.Code.Installers
{
    using global::Code.Core;
    using global::Code.Core.Factories;
    using Projectile;
    using Reflex.Core;
    using Unit.Player;
    using Unit.UnitFactory;
    using Unit.UnitFactory.Abstract;
    using Unit.Units;
    using UnityEngine;

    public class GameplayInstaller : MonoBehaviour, IInstaller
    {
        public CharacterUnitSource<Player> playerUnitSource;
        public CharacterUnitSource<DefaultUnit> defaultUnitSource;
        public CharacterUnitSource<BigUnit> bigUnitSource;
        public CharacterUnitSource<FastUnit> fastUnitSource;
        public void InstallBindings(ContainerBuilder containerBuilder)
        {
            containerBuilder.AddSingleton(typeof(Injector));
            containerBuilder.AddSingleton(typeof(PropsFactory));
            containerBuilder.AddTransient(typeof(Projectile), typeof(IProjectile));
            
            containerBuilder.AddSingleton(_ =>playerUnitSource.CreateUnit(), typeof(Player));
            
            containerBuilder.AddTransient(_ =>defaultUnitSource.CreateUnit(), typeof(DefaultUnit));
            containerBuilder.AddTransient(_ =>bigUnitSource.CreateUnit() , typeof(BigUnit));
            containerBuilder.AddTransient(_ =>fastUnitSource.CreateUnit() , typeof(FastUnit));
            
            Debug.Log("GameplayInstaller InstallBindings");
        }
    }
}
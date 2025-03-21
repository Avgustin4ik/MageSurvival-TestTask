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
        public CharacterUnitSource<FastUnit> smallUnitSource;
        public void InstallBindings(ContainerBuilder containerBuilder)
        {
            containerBuilder.AddSingleton(typeof(Injector));
            containerBuilder.AddSingleton(typeof(PropsFactory));
            containerBuilder.AddTransient(typeof(Projectile), typeof(IProjectile));
            
            containerBuilder.AddSingleton(_ =>playerUnitSource.CreateUnit(), typeof(Player), typeof(CharacterUnitBase));
            containerBuilder.AddTransient(_ =>defaultUnitSource.CreateUnit(), typeof(DefaultUnit), typeof(CharacterUnitBase));
            containerBuilder.AddTransient(_ =>bigUnitSource.CreateUnit() , typeof(BigUnit), typeof(CharacterUnitBase));
            containerBuilder.AddTransient(_ =>smallUnitSource.CreateUnit() , typeof(FastUnit), typeof(CharacterUnitBase));
            Debug.Log("GameplayInstaller InstallBindings");
        }
    }
}
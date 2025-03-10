namespace MageSurvivor.Code.Installers
{
    using Player;
    using Reflex.Core;
    using UnityEngine;

    public class GameplayInstaller : MonoBehaviour, IInstaller
    {
        
        public void InstallBindings(ContainerBuilder containerBuilder)
        {
            containerBuilder.AddSingleton(typeof(Player), typeof(IPlayer));
            Debug.Log("GameplayInstaller InstallBindings");
            
        }
    }
}
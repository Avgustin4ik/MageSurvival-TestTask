namespace MageSurvivor.Code.SceneLauncher
{
    using System;
    using Cysharp.Threading.Tasks;
    using Enemies;
    using global::Code.Core.Factories;
    using Reflex.Attributes;
    using UniRx;
    using Unit.Units;
    using UnityEngine;
    using UnityEngine.AddressableAssets;

    public class SceneLauncher : MonoBehaviour
    {
        public int enemiesLimit = 10;
        public float intervalInSeconds = 1f;
        
        public AssetReferenceT<GameObject> playerPrefab;
        public Transform playerSpawnPoint;
        public EnemySpawner enemySpawner;
        private PropsFactory _propsFactory;
        
        private IDisposable _stream;

        [Inject]
        public void Construct(PropsFactory propsFactory)
        {
            _propsFactory = propsFactory;
        }

        private void Awake()
        {
            SpawnPlayer();
            SoldierMono.count = 0;
            RunEnemySpawner(enemiesLimit, intervalInSeconds).Forget();
        }
        
        private async UniTaskVoid RunEnemySpawner(int maxEnemiesAtTime, float interval)
        {
            _stream = Observable
                .Timer(TimeSpan.Zero, TimeSpan.FromSeconds(interval)) // Периодический таймер
                .Where(_ => SoldierMono.count < maxEnemiesAtTime)   // Проверяем условие
                .Subscribe(async _ =>
                {
                    enemySpawner.SpawnRandomEnemy().Forget();
                })
                .AddTo(this);
        }


        private void OnDestroy()
        {
            _stream?.Dispose();
        }

        private void SpawnPlayer()
        {
            _propsFactory.SpawnInstanceAsync(playerPrefab, playerSpawnPoint.position, playerSpawnPoint.rotation);
        }
    }
}
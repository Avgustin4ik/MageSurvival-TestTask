namespace MageSurvivor.Code.Enemies
{
    using System;
    using Cysharp.Threading.Tasks;
    using global::Code.Core.Factories;
    using Reflex.Attributes;
    using Unit.Units;
    using UnityEngine;
    using UnityEngine.AddressableAssets;
    using Random = UnityEngine.Random;
    public class EnemySpawner : MonoBehaviour
    {
        public Camera mainCamera;
        public float spawnOffset = 1f;
        public SoldierMono enemyPrefab;
        public AssetReferenceT<GameObject> enemyPrefabRef;
        public float spawnCooldown = 1f;
        public Transform groundPlane;
        public LayerMask layerMask;
        public int maxEnemies = 1;
        
        private int _enemyCount;
        private PropsFactory _factory;

        [Inject]
        public void Construct(PropsFactory propsFactory)
        {
            _factory = propsFactory;
        }

        public void Awake()
        {
            //Если камера будет изменяться во время игры, например FOV, то нужно будет пересчитать это в GetRandomSpawnPoint
            SpawnEnemy(enemyPrefabRef, spawnCooldown).Forget();
            _enemyCount = 0;
        }
        private async UniTaskVoid SpawnEnemy(AssetReferenceT<GameObject> enemyPrefab, float cooldownSeconds)
        {
            while (true)
            {
                await UniTask.Delay(TimeSpan.FromSeconds(cooldownSeconds));
                await UniTask
                    .WaitWhile(()=>_enemyCount >= maxEnemies)
                    .ContinueWith(() =>
                    {
                        var spawnPoint = GetRandomSpawnPoint();
                        _factory.SpawnInstanceAsync(this.enemyPrefabRef, spawnPoint, Quaternion.identity).Forget();
                        _enemyCount++;
                        Debug.DrawLine(mainCamera.transform.position, spawnPoint, Color.red, 5f);
                    });
            }
        }

        private async UniTaskVoid SpawnEnemy(SoldierMono enemyPrefab, float cooldownSeconds)
        {
            while (true)
            {
                    await UniTask.Delay(TimeSpan.FromSeconds(cooldownSeconds));
                    await UniTask
                        .WaitWhile(()=>_enemyCount >= maxEnemies)
                        .ContinueWith(() =>
                        {
                            var spawnPoint = GetRandomSpawnPoint();
                            
                            var soldierMono = Instantiate(enemyPrefab, spawnPoint, Quaternion.identity);
                            _enemyCount++;
                            Debug.DrawLine(mainCamera.transform.position, spawnPoint, Color.red, 5f);
                        });
            }
        }
        
        public Vector3 GetRandomSpawnPoint()
        {
            if (mainCamera == null) mainCamera = Camera.main;
            // Получаем углы области видимости и их пересечения с поверхностью
            Vector3[] frustumCorners = GetFrustumCornersOnSurface();
            int side = Random.Range(0, 4);
            var screenPosition = Vector3.zero;
            switch (side)
            {
                case 0: // Top
                    screenPosition = new Vector3(
                        Random.Range(frustumCorners[1].x, frustumCorners[2].x),
                        frustumCorners[1].y,
                        frustumCorners[1].z + spawnOffset);
                    Debug.Log("Top");
                    break;
                case 1: // Bottom
                    screenPosition = new Vector3(
                        Random.Range(frustumCorners[0].x, frustumCorners[3].x),
                        frustumCorners[0].y,
                        frustumCorners[0].z - spawnOffset);
                    Debug.Log("Bottom");
                    break;
                case 2: // Left
                    Debug.Log("Left");
                    screenPosition = new Vector3(
                        frustumCorners[0].x - spawnOffset,
                        frustumCorners[0].y,
                        Random.Range(frustumCorners[0].z,
                            frustumCorners[1].z));
                    break;
                case 3: // Right
                    Debug.Log("Right");
                    screenPosition = new Vector3(
                        frustumCorners[2].x + spawnOffset,
                        frustumCorners[2].y,
                        Random.Range(frustumCorners[1].z,
                            frustumCorners[2].z));
                    break;
            }

            return screenPosition;
        }
        
        
        
        private Vector3[] GetFrustumCornersOnSurface()
        {
            Vector3[] frustumCorners = new Vector3[4];
            mainCamera.CalculateFrustumCorners(new Rect(0, 0, 1, 1), mainCamera.farClipPlane, Camera.MonoOrStereoscopicEye.Mono, frustumCorners);

            for (int i = 0; i < 4; i++)
            {
                var worldSpaceCorner = mainCamera.transform.TransformVector(frustumCorners[i]);
                Debug.DrawRay(mainCamera.transform.position, worldSpaceCorner, Color.cyan, 5f);
                if (Physics.Raycast(mainCamera.transform.position, worldSpaceCorner, out RaycastHit hit, mainCamera.farClipPlane, layerMask))
                {
                    frustumCorners[i] = hit.point;
                }
            }
            Debug.DrawLine(frustumCorners[0], frustumCorners[1], Color.green, 5f);
            Debug.DrawLine(frustumCorners[1], frustumCorners[2], Color.green, 5f);
            Debug.DrawLine(frustumCorners[2], frustumCorners[3], Color.green, 5f);
            Debug.DrawLine(frustumCorners[3], frustumCorners[0], Color.green, 5f);
            return frustumCorners;
        }
    }
}
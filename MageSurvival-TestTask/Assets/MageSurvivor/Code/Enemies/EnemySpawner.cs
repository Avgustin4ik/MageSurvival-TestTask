namespace MageSurvivor.Code.Enemies
{
    using Cysharp.Threading.Tasks;
    using global::Code.Core.Factories;
    using Reflex.Attributes;
    using Services.UnitService;
    using UnityEngine;
    using UnityEngine.AddressableAssets;
    using Random = UnityEngine.Random;
    public class EnemySpawner : MonoBehaviour
    {
        public Camera mainCamera;
        public float spawnOffset = 1f;
        public AssetReferenceT<GameObject> enemyPrefabRef;
        public AssetReferenceT<GameObject> enemyPrefabRef2;
        public AssetReferenceT<GameObject> enemyPrefabRef3;
        public LayerMask layerMask;
        
        private int _enemyCount;
        private PropsFactory _factory;
        private IUnitService _service;

        [Inject]
        public void Construct(PropsFactory propsFactory, IUnitService unitService)
        {
            
            _service = unitService;
            _factory = propsFactory;
        }

        public void Awake()
        {
            _enemyCount = 0;
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

        public async UniTaskVoid SpawnRandomEnemy()
        {
            Vector3 spawnPoint = GetRandomSpawnPoint();
            AssetReferenceT<GameObject> enemyPrefab = _service.GetRandomEnemyUnitPrefab(); 
            _factory.SpawnInstanceAsync(enemyPrefab, spawnPoint, Quaternion.identity);
        }
    }
}
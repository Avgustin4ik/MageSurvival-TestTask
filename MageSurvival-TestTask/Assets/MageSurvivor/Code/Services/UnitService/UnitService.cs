namespace MageSurvivor.Code.Services.UnitService
{
    using Core.Abstract.Service;
    using Unit.Player;
    using Unit.Units;
    using UnityEngine;
    using UnityEngine.AddressableAssets;
    
    public class UnitService : Service, IUnitService
    {
        private readonly AssetReferenceT<GameObject> _player;
        private readonly AssetReferenceT<GameObject>[] _enemies;

        public UnitService(AssetReferenceT<GameObject> player, params AssetReferenceT<GameObject>[] enemies)
        {
            _player = player;
            _enemies = enemies;
        }

        public AssetReferenceT<GameObject> GetRandomEnemyUnitPrefab()
        {
            return _enemies[Random.Range(0, _enemies.Length)];
        }

        public AssetReferenceT<GameObject> GetUnit<T>() where T : CharacterMono
        {
            return typeof(T) == typeof(Player) ? _player : null;
        }
    }
}
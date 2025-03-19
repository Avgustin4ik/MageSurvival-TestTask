namespace MageSurvivor.Code.Services.UnitService
{
    using Unit.Units;
    using UnityEngine;
    using UnityEngine.AddressableAssets;

    public interface IUnitService
    {
        public AssetReferenceT<GameObject> GetRandomEnemyUnitPrefab();
        public AssetReferenceT<GameObject> GetUnit<T>() where T : CharacterMono;
    }
}
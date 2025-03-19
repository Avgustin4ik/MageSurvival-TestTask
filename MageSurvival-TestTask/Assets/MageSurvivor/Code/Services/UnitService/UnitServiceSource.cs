namespace MageSurvivor.Code.Services.UnitService
{
    using Core.Abstract.Service;
    using UnityEngine;
    using UnityEngine.AddressableAssets;

    [CreateAssetMenu(fileName = "UnitServiceSource", menuName = "MageSurvivor/Services/UnitServiceSource")]
    public class UnitServiceSource : ServiceSource<UnitService>
    {
        public AssetReferenceT<GameObject>[] Enemies;
        public AssetReferenceT<GameObject> Player;
        protected override UnitService CreateServiceInstance()
        {
            return new UnitService(Player, Enemies);
        }
    }
}
namespace MageSurvivor.Code.Core.UiService
{
    using System;
    using System.Collections.Generic;
    using global::Code.Core.Abstract;
    using global::Code.Core.Abstract.Service;
    using global::Code.Core.UiService;
    using UnityEngine;
    using UnityEngine.AddressableAssets;

    public class UiService : Service, IUiService
    {
        private readonly Dictionary<Type, string> _uiAssets;

        public UiService(Dictionary<Type, string> assetCollection)
        {
            _uiAssets = assetCollection;
        }

        public GameObject GetUiPrefab<T>() where T : BaseView
        {
            throw new NotImplementedException();
        }

        public AssetReference GetUiAssetReference<T>() where T : BaseView => new(_uiAssets[typeof(T)]);
    }
}
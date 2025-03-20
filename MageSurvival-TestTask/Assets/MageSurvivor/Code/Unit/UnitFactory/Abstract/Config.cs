namespace MageSurvivor.Code.Unit.UnitFactory.Abstract
{
    using System;
    using UnityEngine;
    using UnityEngine.AddressableAssets;

    [Serializable]
    public class Config
    {
        public int Health;
        [Range(0f,1f)]
        public float Armor;
        
        public int Damage;
        public float AttackSpeed;
        public float AttackRange;
        public float MoveSpeed;
        public AssetReferenceT<GameObject> PrefabReference;
    }
}
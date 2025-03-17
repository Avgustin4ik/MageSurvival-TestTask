namespace MageSurvivor.Code.Unit.UnitFactory.Abstract
{
    using System;
    using UnityEngine;
    using UnityEngine.AddressableAssets;

    [Serializable]
    public class Config
    {
        public int Health;
        public int Armor;
        public int Damage;
        public float AttackSpeed;
        public float AttackRange;
        public float MoveSpeed;
        public AssetReferenceT<GameObject> PrefabReference;
    }
}
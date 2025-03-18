namespace MageSurvivor.Code.Common.Projectile
{
    using System;
    using UnityEngine;

    public class Projectile : IProjectile
    {
        public Vector3 Position { get; private set; }
        private Vector3 _direction;
        private float _speed;
        
        public void Launch(Vector3 position)
        {
            throw new System.NotImplementedException();
        }

        public void LaunchDirection(Vector3 direction)
        {
            throw new System.NotImplementedException();
        }
        //мне не нравится что я буду вызвать это из монобеха. Это можно избежать, вызывая самописный Tick
        //например такой есть в Zenject ITickable либо можно использовать UniRx чтобы обновлять позицию
        //но при использовании UniRx мне не нравится идея создания стрима для каждого снаряда (надо пулить, выглядит ка клишний геморой)
        public void Launch(Vector3 direction, float speed)
        {
            _direction = direction;
            _speed = speed;
        }

        public void UpdatePosition(float deltaTime)
        {
            if (_direction == Vector3.zero)
            {
                throw new NotImplementedException("Projectile direction is zero");
            }
        }


        public void Destroy()
        {
            
        }

        public void Hit(GameObject otherGameObject)
        {
            throw new System.NotImplementedException($"{this.GetType().Name} hit {otherGameObject.name}");
        }
    }
}
namespace MageSurvivor.Code.Unit.Player
{
    using System;
    using Reflex.Attributes;
    using UnityEngine;

    public class FollowingCamera : MonoBehaviour
    {
        [Inject] private Player target; // Предполагаю, что Player имеет свойство position
        public float smoothSpeed = 0.125f; // Скорость сглаживания движения
        public Vector3 offset = new Vector3(0, 0, -5); // Смещение относительно игрока
        public Vector2 deadZone = new Vector2(2f, 2f); // Мёртвая зона по X и Z
        public float fixedHeight = 10f; // Фиксированная высота камеры (можно настроить в инспекторе)
        private Vector3 velocity = Vector3.zero; // Для SmoothDamp
        private void Awake()
        {
            fixedHeight = transform.position.y;
        }

        private void LateUpdate()
        {
            if (target == null) return;

            // Текущая позиция камеры
            Vector3 currentPosition = transform.position;

            // Желаемая позиция с учётом смещения и фиксированной высоты
            Vector3 desiredPosition = new Vector3(
                target.position.x + offset.x,
                fixedHeight,
                target.position.z + offset.z
            );

            // Вычисляем разницу между текущей позицией и желаемой
            Vector3 delta = desiredPosition - currentPosition;

            // Целевая позиция с учётом deadZone
            Vector3 targetPosition = currentPosition;

            // Проверяем выход за пределы deadZone по X
            if (Mathf.Abs(delta.x) > deadZone.x)
            {
                targetPosition.x = desiredPosition.x - Mathf.Sign(delta.x) * deadZone.x;
            }

            // Проверяем выход за пределы deadZone по Z
            if (Mathf.Abs(delta.z) > deadZone.y)
            {
                targetPosition.z = desiredPosition.z - Mathf.Sign(delta.z) * deadZone.y;
            }

            // Фиксируем высоту
            targetPosition.y = fixedHeight;

            // Плавное движение с помощью SmoothDamp
            transform.position = Vector3.SmoothDamp(
                currentPosition,
                targetPosition,
                ref velocity,
                smoothSpeed
            );
        }
    }
}
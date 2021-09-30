using UnityEngine;

namespace Assets.GameLogic.Scripts
{
    [CreateAssetMenu(menuName = "Ship/Settings", fileName = "ShipData")]
    public class ShipSettings : ScriptableObject
    {

        [SerializeField] private float moveSpeed = 5.0f;
        [SerializeField] private float maxVelocity = 5.0f;
        [SerializeField] private float rotationSpeed = 250.0f;        
        [SerializeField] private float friction = 0.95f;
        [SerializeField] private int   pointsPerDestroying = 100;
        [SerializeField] private bool  useAi = false;

        /// <summary>
        /// Ускорение корабля
        /// </summary>
        public float MoveSpeed { get => this.moveSpeed; }

        /// <summary>
        /// Максимальная скорость корабля
        /// </summary>
        public float MaxVelocity { get => this.maxVelocity; }

        /// <summary>
        /// Скорость поворота корабля
        /// </summary>
        public float RotationSpeed { get => this.rotationSpeed; }

        /// <summary>
        /// Сила трения
        /// </summary>
        public float Friction { get => this.friction; }

        /// <summary>
        /// Очки за уничтожение объекта
        /// </summary>
        public int PointsPerDestroying { get => this.pointsPerDestroying; }

        /// <summary>
        /// Флаг использования ИИ для управления кораблем
        /// </summary>
        public bool UseAi { get => this.useAi; }

    }
}

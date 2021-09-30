namespace Assets.GameLogic.Scripts.GameEntities.Models
{

    /// <summary>
    /// Неизменяемая структура для хранения координат Игрока
    /// </summary>
    public struct PlayerCoordinates
    {

        /// <summary>
        /// Конструктор
        /// </summary>
        public PlayerCoordinates(float x, float y)
        {
            this.CoordinateX = x;
            this.CoordinateY = y;
        }

        /// <summary>
        /// Координата в плоскости X
        /// </summary>
        public readonly float CoordinateX { get; }

        /// <summary>
        /// Координата в плоскости Y
        /// </summary>
        public readonly float CoordinateY { get; }

    }
}

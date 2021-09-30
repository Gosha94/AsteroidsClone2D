namespace Assets.GameLogic.Scripts.GameEntities.Models.Common
{
    /// <summary>
    /// Модель данных игрока, передаваемая в UI
    /// </summary>
    public sealed class PlayerData
    {

        public PlayerCoordinates PlayerCoordinates { get; set; }
        public float AngleShip { get; set; }
        public float SpeedShipValue { get; set; }
        public int LaserCountShip { get; set; }
        public int LaserReloadShipTime { get; set; }

    }
}
namespace Assets.GameLogic.Scripts.Contracts
{
    /// <summary>
    /// Интерфейс ввода для корабля
    /// </summary>
    public interface IShipInput
    {
        /// <summary>
        /// Метод чтения пользовательского ввода
        /// </summary>
        void ReadInput();

        /// <summary>
        /// Свойство определяет поворот корабля
        /// </summary>
        float Rotation { get; }

        /// <summary>
        /// Свойство определяет тягу корабля
        /// </summary>
        float Thrust { get; }

        /// <summary>
        /// Свойство определяет огонь из основного вооружения
        /// </summary>
        bool PrimaryWeaponFire { get; }

        /// <summary>
        /// Свойство определяет огонь из вторичного вооружения
        /// </summary>
        bool SeconaryWeaponFire { get; }
    }
}

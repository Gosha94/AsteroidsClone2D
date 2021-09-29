namespace Assets.GameLogic.Scripts.Contracts
{
    /// <summary>
    /// Интерфейс описывает двигатель игрового объекта (корабль, астероид и т.д.)
    /// </summary>
    public interface IEngine
    {
        /// <summary>
        /// Метод движения игрового объекта по определенному алгоритму
        /// </summary>
        void Tick();
    }
}

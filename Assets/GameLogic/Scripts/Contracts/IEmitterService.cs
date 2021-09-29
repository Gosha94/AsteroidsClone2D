using System;

namespace Assets.GameLogic.Scripts.Contracts
{

    /// <summary>
    /// Интерфейс для описания сущности, генерирующей объекты (Эмиттера объектов)
    /// </summary>
    public interface IEmitterService
    {

        /// <summary>
        /// Событие, активируется при уничтожении каждого уничтоженного объекта, созданного Эмиттером
        /// </summary>
        public event Action<int> EntityDestroyedEvent;

        /// <summary>
        /// Свойство определяет оставшееся на игровом поле число объектов Эмиттера
        /// </summary>
        int GameEntitiesLeft { get; }

        /// <summary>
        /// Метод уничтожает игровые объекты, созданные Эмиттером
        /// </summary>
        void ResetEmitter();

        /// <summary>
        ///  Метод создает игровые объекты
        /// </summary>
        void SpawnGameEntity();
    }

}
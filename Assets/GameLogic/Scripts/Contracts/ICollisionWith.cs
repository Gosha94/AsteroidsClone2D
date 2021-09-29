using System;
using UnityEngine;

namespace Assets.GameLogic.Scripts.Contracts
{

    /// <summary>
    /// Интерфейс описывает коллизию коллайдеров игровых объектов
    /// </summary>
    public interface ICollisionWith<T>
    {
        /// <summary>
        /// Событие, срабатывает при коллизии
        /// </summary>
        event Action<T> CollisionEvent;

        /// <summary>
        /// Метод обработки коллизии с объектами
        /// </summary>
        /// <param name="collider"></param>
        void OnTriggerEnter2D(Collider2D collider);

    }
}

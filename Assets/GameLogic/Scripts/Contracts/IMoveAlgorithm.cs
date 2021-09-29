using UnityEngine;

namespace Assets.GameLogic.Scripts.Contracts
{

    /// <summary>
    /// Интерфейс описывает алгоритм движения объекта, реализующего данный интерфейс
    /// </summary>
    public interface IMoveAlgorithm
    {
        /// <summary>
        /// Метод движения, основанный на конкретном алгоритме
        /// </summary>
        void MovingBasedOnAlgorithm(Transform transformObj);
    }
}

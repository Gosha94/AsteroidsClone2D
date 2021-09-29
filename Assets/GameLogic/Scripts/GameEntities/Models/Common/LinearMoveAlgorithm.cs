using UnityEngine;
using Assets.GameLogic.Scripts.Contracts;

namespace Assets.GameLogic.Scripts.GameEntities.Models
{

    /// <summary>
    /// (запрет на наследование) Класс содержит реализацию линейного движения
    /// </summary>
    public sealed class LinearMoveAlgorithm : IMoveAlgorithm
    {
        private Quaternion initialRotation;
        private float moveSpeed;

        public LinearMoveAlgorithm(Quaternion rotationObj , float speedObj)
        {
            this.initialRotation = new Quaternion(rotationObj.x, rotationObj.y, rotationObj.z, rotationObj.w);
            this.moveSpeed = speedObj;
        }
        
        /// <summary>
        /// Метод занимается движением объекта по прямой
        /// </summary>
        /// <param name="transformObj">Объект, который предполагается передвигать</param>
        /// <param name="moveSpeed">Скорость передвижения объекта</param>
        public void MovingBasedOnAlgorithm(Transform transformObj)
        {
            transformObj.rotation = this.initialRotation;
            transformObj.transform.Translate(transformObj.transform.up * moveSpeed * Time.deltaTime, Space.World);
        }

    }
}

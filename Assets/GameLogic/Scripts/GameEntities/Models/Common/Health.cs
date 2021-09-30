using Assets.GameLogic.Scripts.GameEntities.GameBehaviours.Controllers;
using System;
using UnityEngine;

namespace Assets.GameLogic.Scripts.GameEntities.Models
{
    /// <summary>
    /// Класс описывает модель Здоровья
    /// </summary>
    public class Health : MonoBehaviour
    {

        private int healthValue = 1;

        #region Public Properties

        /// <summary>
        /// Событие Здоровье Изменилось
        /// </summary>
        public event Action<int> HealthChangedEvent;

        /// <summary>
        /// Свойство содержит значение Здоровья
        /// </summary>
        public int HealthValue
        {
            get => this.healthValue;
            private set
            {
                NormalizeNegativeHealth(ref value);
                this.healthValue = value;
            }
        }

        #endregion

        #region Public API

        /// <summary>
        /// Метод снижения здоровья
        /// </summary>
        /// <param name="reducingValue"></param>
        public void ReduceHealth(int reducingValue)
        {
            this.HealthValue -= reducingValue;
            RaiseEventHealthChanged();
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// Метод нормализует отрицательное здоровье
        /// </summary>
        private void NormalizeNegativeHealth(ref int healthForNormalize)
        {
            if (healthForNormalize < 0)
            {
                healthForNormalize = 0;
            }
        }

        /// <summary>
        /// Метод пробуждает событие Здоровье Изменилось
        /// </summary>
        private void RaiseEventHealthChanged()
        {
            this.HealthChangedEvent?.Invoke(this.HealthValue);
            ApplicationLoggerService.LogHealthChange(this.gameObject.tag);            
        }

        #endregion

    }
}

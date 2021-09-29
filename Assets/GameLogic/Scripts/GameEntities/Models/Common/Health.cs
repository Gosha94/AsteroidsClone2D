using System;

namespace Assets.GameLogic.Scripts.GameEntities.Models
{
    /// <summary>
    /// Класс описывает модель Здоровья
    /// </summary>
    public class Health
    {

        private int healthValue = 1;

        #region Public Properties

        /// <summary>
        /// Событие Здоровье Изменилось
        /// </summary>
        public event Action<int> HealthChangedEvent;

        /// <summary>
        /// Событие Здоровье Закончилось
        /// </summary>
        public event Action HealthIsEmptyEvent;

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
        /// Метод пробуждает событие Здоровье Закончилось
        /// </summary>
        private void RaiseEventHealthIsEmpty()
            => this.HealthIsEmptyEvent?.Invoke();

        /// <summary>
        /// Метод пробуждает событие Здоровье Изменилось
        /// </summary>
        private void RaiseEventHealthChanged()
            => this.HealthChangedEvent?.Invoke(this.HealthValue);

        #endregion

    }
}

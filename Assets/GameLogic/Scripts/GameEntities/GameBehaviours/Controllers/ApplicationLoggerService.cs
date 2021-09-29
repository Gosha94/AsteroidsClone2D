﻿using UnityEngine;

namespace Assets.GameLogic.Scripts.GameEntities.GameBehaviours.Controllers
{
    /// <summary>
    /// Служба Логирования приложения
    /// </summary>
    public class ApplicationLoggerService
    {

        /// <summary>
        /// Метод записи в лог Здоровья объекта
        /// </summary>
        /// <param name="whoObjectTag">Тег логируемого объекта</param>
        /// <param name="currentHealth">Текущее значение здоровья</param>
        public static void LogHealth(string whoObjectTag, int currentHealth)
        {
            Debug.Log($"Здоровье объекта {whoObjectTag} равно {currentHealth.ToString()}");
        }

        /// <summary>
        /// Метод записи в лог события Коллизия
        /// </summary>
        /// <param name="whoObjectTag">Тег логируемого объекта</param>
        /// <param name="withObjectTag">Тег объекта столкновения</param>
        public static void LogCollision(string whoObjectTag, string withObjectTag)
        {
            Debug.Log($"Объект {whoObjectTag} столкнулся с {withObjectTag}");
        }
    }
}

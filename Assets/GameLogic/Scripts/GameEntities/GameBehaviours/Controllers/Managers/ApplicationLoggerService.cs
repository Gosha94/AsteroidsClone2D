using UnityEngine;

namespace Assets.GameLogic.Scripts.GameEntities.GameBehaviours.Controllers
{
    /// <summary>
    /// Служба Логирования приложения
    /// </summary>
    public class ApplicationLoggerService
    {

        /// <summary>
        /// Метод логирует окончание передачи данных пользователя в UI
        /// </summary>
        public static void LogFinishTransferPlayerData()
        {
            Debug.Log("Данные игрока переданы в UI");
        }

        /// <summary>
        /// Метод логирует ошибку отсутствия прикрепленного объекта в Unity
        /// </summary>
        public static void LogNullReferenceError()
        {
            Debug.Log($"Обнаружен пустой объект Корабля, движение за ним невозможно!");
        }

        /// <summary>
        /// Метод записи в лог Факта изменения здоровья
        /// </summary>
        /// <param name="tagName">Имя Объекта</param>
        public static void LogHealthChange(string tagName)
        {
            Debug.Log($"Здоровье объекта {tagName} изменилось!");
        }

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

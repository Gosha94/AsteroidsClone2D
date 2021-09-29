using System;
using UnityEngine;

namespace Assets.GameLogic.Scripts.GameEntities.GameBehaviours
{

    /// <summary>
    /// Класс отвечает за обработку уничтожения Игрока
    /// </summary>
    public class ShipDied : MonoBehaviour
    {

        #region Private Fields

        [SerializeField] private GameObject explosionPrefab;

        [SerializeField] private float dieDuration = 1.0f;

        private GameObject explosionObj;

        #endregion

        #region Public API

        /// <summary>
        /// Событие для оповещения об уничтожении корабля
        /// </summary>
        public event Action ShipDieCompleteEvent;

        /// <summary>
        /// Метод уничтожения игрока
        /// </summary>
        public void Die()
        {
            explosionObj = Instantiate(explosionPrefab, transform.position, Quaternion.identity);
            Invoke("FinalizeAfterDie", dieDuration);
        }

        #endregion

        /// <summary>
        /// Метод для обработки доп.логики при уничтожении корабля игрока
        /// </summary>
        private void FinalizeAfterDie()
        {
            Destroy(explosionObj);
            ShipDieCompleteEvent?.Invoke();
        }

    }
}
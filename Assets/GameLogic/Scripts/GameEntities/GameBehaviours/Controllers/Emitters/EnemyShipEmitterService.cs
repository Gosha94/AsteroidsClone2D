using System;
using UnityEngine;
using System.Collections.Generic;
using Assets.GameLogic.Scripts.Contracts;
using Assets.GameLogic.Scripts.ScriptableObjects;

namespace Assets.GameLogic.Scripts.GameEntities.GameBehaviours.Controllers
{
    public class EnemyShipEmitterService : MonoBehaviour, IEmitterService
    {

        #region Private Fields

        [SerializeField] private GameObject enemyShipPrefab;
        [SerializeField] private GameEntitesEmitterSettings emitterSettings;

        private List<Ship> enemyShipsList;

        #endregion

        #region Public Properties

        public int GameEntitiesLeft { get => this.enemyShipsList.Count; }

        public event Action<int> EntityDestroyedEvent;

        #endregion

        #region Mono Methods

        private void Awake()
        {
            ResetEmitter();
        }

        #endregion

        #region Public API

        public void ResetEmitter()
        {
            if (this.enemyShipsList != null)
            {
                this.enemyShipsList
                    .ForEach(x =>
                    {
                        Destroy(x.gameObject);
                    });
            }

            this.enemyShipsList = new List<Ship>();
        }

        public void SpawnGameEntity()
        {
            int maxEntitiesNum = this.emitterSettings.StartingEntitiesCount;

            for (int i = 0; i < maxEntitiesNum; i++)
            {
                CreateEnemyShip(enemyShipPrefab, emitterSettings.GetRandomOffScreenPosition());
            }
        }

        #endregion

        #region Private Methods

        private Ship CreateEnemyShip(GameObject prefab, Vector3 position)
        {
            GameObject enemyShipObj = Instantiate(prefab, position, Quaternion.identity) as GameObject;

            Ship enemyShip = enemyShipObj.GetComponent<Ship>();

            enemyShip.ShipDiedEvent += OnEnemyShipDie;

            this.enemyShipsList.Add(enemyShip);
            return enemyShip;
        }

        /// <summary>
        /// Метод вызывается при уничтожении Вражеского Корабля
        /// </summary>
        /// <param name="enemyShip"></param>
        /// <param name="scoreForDestroying"></param>
        /// <param name="position"></param>
        private void OnEnemyShipDie(Ship enemyShip, int scoreForDestroying, Vector3 position)
        {
            ApplicationLoggerService.LogHealthChange(enemyShip.tag);

            this.enemyShipsList.Remove(enemyShip);

            EntityDestroyedEvent?.Invoke(scoreForDestroying);
        }

        #endregion

    }
}

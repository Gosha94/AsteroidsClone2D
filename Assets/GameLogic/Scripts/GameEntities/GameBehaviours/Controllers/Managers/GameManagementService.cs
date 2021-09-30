using System;
using UnityEngine;
using Assets.GameLogic.Scripts.GameEntities.Models;
using Assets.GameLogic.Scripts.GameEntities.Models.Common;

namespace Assets.GameLogic.Scripts.GameEntities.GameBehaviours.Controllers
{

    /// <summary>
    /// Служба управления игровым процессом
    /// </summary>
    public class GameManagementService : MonoBehaviour
    {

        #region Private Fields

        [SerializeField] private int level;
        [SerializeField] private AsteroidEmitterService asteroidEmitter;
        [SerializeField] private EnemyShipEmitterService enemyEmitter;
        [SerializeField] private Ship playerShip;
        [SerializeField] private float startLevelDelay = 3.0f;

        private bool flagOfEndingAsteroids;
        private bool flagOfEndingEnemyShips;
        private PlayerData currentPlayerRealTimeData;

        #endregion

        #region Public Properties

        /// <summary>
        /// Событие увеличения счета в игре
        /// </summary>
        public event Action<int> IncreaseScoreEvent;

        /// <summary>
        /// Событие уничтожения игрока
        /// </summary>
        public event Action PlayerDiedEvent;

        /// <summary>
        /// Событие начала игры
        /// </summary>
        public event Action GameStartedEvent;

        public int Level
        {
            get => this.level;
            private set { this.level = value; }
        }

        #endregion

        #region Mono Methods

        private void Awake()
        {
            this.currentPlayerRealTimeData = new PlayerData();

            this.asteroidEmitter.EntityDestroyedEvent += OnAsteroidDestroyed;
            this.enemyEmitter.EntityDestroyedEvent += OnEnemyShipDestroyed;
            this.playerShip.ShipDiedEvent += OnPlayerDied;

            ResetFlagsOfLeftEmittedEntitiesInGame();
        }

        public void Reset()
        {
            level = 1;
            asteroidEmitter.ResetEmitter();
            enemyEmitter.ResetEmitter();
        }

        #endregion

        #region Public Methods

        public void StartLevel()
        {
            ResetFlagsOfLeftEmittedEntitiesInGame();

            asteroidEmitter.SpawnGameEntity();
            enemyEmitter.SpawnGameEntity();
            GameStartedEvent?.Invoke();
        }

        public void SpawnPlayer()
        {
            playerShip.ShipSpawn();
        }

        /// <summary>
        /// Метод предачи параметров игрока в UI
        /// </summary>
        /// <returns >Данные игрока</returns>
        public PlayerData GetPlayerData()
        {
            FillPlayerData();
            ApplicationLoggerService.LogFinishTransferPlayerData();
            return this.currentPlayerRealTimeData;
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// Метод заполняет модель данных игрока
        /// </summary>
        private void FillPlayerData()
        {
            this.currentPlayerRealTimeData.PlayerCoordinates = new PlayerCoordinates(this.playerShip.transform.position.x, this.playerShip.transform.position.y);
            this.currentPlayerRealTimeData.AngleShip = this.playerShip.ShipAngle;
            this.currentPlayerRealTimeData.SpeedShipValue = this.playerShip.ShipSpeed;
            this.currentPlayerRealTimeData.LaserCountShip = 1;
            this.currentPlayerRealTimeData.LaserReloadShipTime = 1;
        }

        /// <summary>
        /// Метод, запускаемый при запуске события Астероид уничтожен
        /// </summary>
        /// <param name="scoreForDestroying">Очки за уничтожение</param>
        private void OnAsteroidDestroyed(int scoreForDestroying)
        {
            IncreaseScoreEvent?.Invoke(scoreForDestroying);

            if (asteroidEmitter.GameEntitiesLeft == 0)
            {
                this.flagOfEndingAsteroids = true;
                CheckOnStartLevelAgain();
            }
        }

        /// <summary>
        /// Метод, запускаемый при запуске события Корабль противника уничтожен
        /// </summary>
        /// <param name="scoreForDestroying">Очки за уничтожение</param>
        private void OnEnemyShipDestroyed(int scoreForDestroying)
        {
            IncreaseScoreEvent?.Invoke(scoreForDestroying);

            if (enemyEmitter.GameEntitiesLeft == 0)
            {
                this.flagOfEndingEnemyShips = true;
                CheckOnStartLevelAgain();
            }
        }

        /// <summary>
        /// Метод сбрасывает флаги окончания игровых сущностей в игре
        /// </summary>
        private void ResetFlagsOfLeftEmittedEntitiesInGame()
        {
            this.flagOfEndingAsteroids = false;
            this.flagOfEndingEnemyShips = false;
        }

        /// <summary>
        /// Метод запускает уровень сначала с сохранением игрового Счета
        /// </summary>
        private void CheckOnStartLevelAgain()
        {
            if (this.flagOfEndingAsteroids && this.flagOfEndingEnemyShips)
            {
                level += 1;
                Invoke("StartLevel", startLevelDelay);
            }
        }

        /// <summary>
        /// Метод, запускаемый при запуске события Корабль уничтожен
        /// </summary>
        /// <param name="ship">Объект Корабля</param>
        /// <param name="scoreForDestroying">Очки за уничтожение</param>
        /// <param name="position">Позиция Корабля</param>
        private void OnPlayerDied(Ship ship, int scoreForDestroying, Vector3 position)
        {
            PlayerDiedEvent?.Invoke();
        }

        #endregion

    }
}

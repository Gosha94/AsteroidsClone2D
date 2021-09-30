using System;
using UnityEngine;

namespace Assets.GameLogic.Scripts.GameEntities.GameBehaviours.Controllers
{

    /// <summary>
    /// Служба управления игровым процессом
    /// </summary>
    public class GameManagementService : MonoBehaviour
    {
        public event Action<int> IncreaseScoreEvent;
        /// <summary>
        /// Событие уничтожения игрока
        /// </summary>
        public event Action PlayerDiedEvent;

        /// <summary>
        /// Событие начала игры
        /// </summary>
        public event Action GameStartedEvent;

        [SerializeField] private int level;
        [SerializeField] private AsteroidEmitterService asteroidEmitter;
        [SerializeField] private EnemyShipEmitterService enemyEmitter;
        [SerializeField] private Ship playerShip;
        [SerializeField] private float startLevelDelay = 3.0f;

        private bool flagOfEndingAsteroids;
        private bool flagOfEndingEnemyShips;

        public int Level
        {
            get { return level; }
            private set { level = value; }
        }

        private void Awake()
        {
            asteroidEmitter.EntityDestroyedEvent += OnAsteroidDestroyed;
            enemyEmitter.EntityDestroyedEvent += OnEnemyShipDestroyed;
            playerShip.ShipDiedEvent += OnPlayerDied;

            ResetFlagsOfLeftEmittedEntitiesInGame();
        }

        public void Reset()
        {
            level = 1;
            asteroidEmitter.ResetEmitter();
            enemyEmitter.ResetEmitter();
        }

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

    }
}

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
        public event Action PlayerDiedEvent;
        public event Action GameStartedEvent;

        [SerializeField] private int level;
        [SerializeField] private AsteroidEmitterService asteroidEmitter;
        [SerializeField] private Ship playerShip;
        [SerializeField] private float startLevelDelay = 3.0f;

        public int Level
        {
            get { return level; }
            private set { level = value; }
        }

        private void Awake()
        {
            asteroidEmitter.EntityDestroyedEvent += OnAsteroidDestroyed;
            playerShip.PlayerDiedEvent += OnPlayerDied;
        }

        public void Reset()
        {
            level = 1;
            asteroidEmitter.ResetEmitter();
        }

        public void StartLevel()
        {
            asteroidEmitter.SpawnGameEntity();
            GameStartedEvent?.Invoke();
        }

        public void SpawnPlayer()
        {
            playerShip.ShipSpawn();
        }

        private void OnAsteroidDestroyed(int points)
        {
            IncreaseScoreEvent?.Invoke(points);

            // check if there are any asteroids remaining
            if (asteroidEmitter.GameEntitiesLeft == 0)
            {
                level += 1;
                Invoke("StartLevel", startLevelDelay);
            }
        }

        private void OnPlayerDied()
        {
            PlayerDiedEvent?.Invoke();
        }

    }
}

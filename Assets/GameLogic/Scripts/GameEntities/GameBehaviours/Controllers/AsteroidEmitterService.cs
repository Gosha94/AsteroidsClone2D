using System;
using UnityEngine;
using System.Collections.Generic;
using Assets.GameLogic.Scripts.Contracts;
using Assets.GameLogic.Scripts.ScriptableObjects;

namespace Assets.GameLogic.Scripts.GameEntities.GameBehaviours.Controllers
{
    /// <summary>
    /// Класс описывает Генератор астероидов
    /// </summary>
    public class AsteroidEmitterService : MonoBehaviour, IEmitterService
    {
        
        #region Private Fields

        [SerializeField] private GameObject asteroidPrefab;
        [SerializeField] private GameEntitesEmitterSettings emitterSettings;

        private List<Asteroid> asteroidList;

        #endregion

        #region Public Properties

        public event Action<int> EntityDestroyedEvent;

        public int GameEntitiesLeft
        {
            get => this.asteroidList.Count;
        }

        #endregion

        private void Awake()
        {
            ResetEmitter();
        }

        #region Public API
        
        public void ResetEmitter()
        {
            if (asteroidList != null)
            {
                this.asteroidList
                    .ForEach(x =>
                    {
                        Destroy(x.gameObject);
                    });
            }

            asteroidList = new List<Asteroid>();
        }
        
        public void SpawnGameEntity()
        {
            int maxAsteroidsNum = this.emitterSettings.StartingEntitiesCount;

            for (int i = 0; i < maxAsteroidsNum; i++)
            {
                CreateAsteroid(asteroidPrefab, emitterSettings.GetRandomOffScreenPosition(), emitterSettings.GetRandomOffScreenRotation());
            }
        }

        #endregion

        #region Private Methods

        private Asteroid CreateAsteroid(GameObject prefab, Vector3 position, Quaternion rotation)
        {
            GameObject asteroidGO = Instantiate(prefab, position, rotation) as GameObject;
            asteroidGO.transform.SetParent(gameObject.transform);

            Asteroid asteroid = asteroidGO.GetComponent<Asteroid>();

            asteroid.EventDie += OnAsteroidDie;

            asteroidList.Add(asteroid);
            return asteroid;
        }

        /// <summary>
        /// Метод вызывается при уничтожении астероида, создаются мини-Астероиды, если у уничтоженного Астероида есть дочерние объекты
        /// </summary>
        /// <param name="asteroid">Объект уничтоженного Астероида</param>
        /// <param name="points">Количество очков за уничтожение</param>
        /// <param name="position">Позиция уничтожения Астероида</param>
        /// <param name="childAsteroids">Массив дочерних Астероидов</param>
        private void OnAsteroidDie(Asteroid asteroid, int points, Vector3 position, GameObject[] childAsteroids)
        {
            asteroidList.Remove(asteroid);

            for (int i = 0; i < childAsteroids.Length; i++)
            {
                Quaternion rotation = Quaternion.Euler(new Vector3(0.0f, 0.0f, Mathf.Floor(UnityEngine.Random.Range(0.0f, 360.0f))));
                CreateAsteroid(childAsteroids[i], position, rotation);
            }
            EntityDestroyedEvent?.Invoke(points);
        }

        #endregion

    }
}
using System;
using System.Linq;
using UnityEngine;
using System.Collections.Generic;
using Assets.GameLogic.Scripts.ScriptableObjects;

namespace Assets.GameLogic.Scripts.GameEntities.GameBehaviours.Controllers
{
    /// <summary>
    /// ����� ��������� ��������� ����������
    /// </summary>
    public class AsteroidEmitterService : MonoBehaviour
    {

        [SerializeField] private GameObject asteroidPrefab;
        [SerializeField] private GameEntitesEmitterSettings emitterSettings;

        private List<Asteroid> asteroids;

        public event Action<int> AsteroidDestroyedEvent;

        
        public int GameEntitiesLeft
        {
            get => asteroids.Count;
        }

        private void Awake()
        {
            ResetEmitter();
        }

        #region Public API
        
        public void ResetEmitter()
        {
            if (asteroids != null)
            {
                this.asteroids
                    .ForEach(x =>
                    {
                        Destroy(x.gameObject);
                    });
            }

            asteroids = new List<Asteroid>();
        }

        /// <summary>
        /// ����� ������� ��������� � ����������� �� EmitterSettings
        /// </summary>
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

            asteroids.Add(asteroid);
            return asteroid;
        }

        /// <summary>
        /// ����� ���������� ��� ����������� ���������, ��������� ����-���������, ���� � ������������� ��������� ���� �������� �������
        /// </summary>
        /// <param name="asteroid">������ ������������� ���������</param>
        /// <param name="points">���������� ����� �� �����������</param>
        /// <param name="position">������� ����������� ���������</param>
        /// <param name="childAsteroids">������ �������� ����������</param>
        private void OnAsteroidDie(Asteroid asteroid, int points, Vector3 position, GameObject[] childAsteroids)
        {
            asteroids.Remove(asteroid);

            for (int i = 0; i < childAsteroids.Length; i++)
            {
                Quaternion rotation = Quaternion.Euler(new Vector3(0.0f, 0.0f, Mathf.Floor(UnityEngine.Random.Range(0.0f, 360.0f))));
                CreateAsteroid(childAsteroids[i], position, rotation);
            }

            AsteroidDestroyedEvent?.Invoke(points);

        }

        #endregion

    }
}
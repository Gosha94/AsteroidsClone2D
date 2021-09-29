using System;
using UnityEngine;
using Assets.GameLogic.Scripts.Contracts;
using Assets.GameLogic.Scripts.ScriptableObjects;
using Assets.GameLogic.Scripts.GameEntities.Models;

namespace Assets.GameLogic.Scripts.GameEntities.GameBehaviours
{

	/// <summary>
	/// Класс определяет поведение Астероида в игре
	/// </summary>
	public class Asteroid : MonoBehaviour
	{

		#region Private Fields

		[SerializeField] private int pointsValue;
		[SerializeField] private GameObject[] asteroidPieces;
		[SerializeField] private GameObject[] childAsteroids;
		[SerializeField] private GameObject explosionFractionsPrefab;

		private Health health;
		private IMoveAlgorithm moveAlgorithm;

		#endregion

		#region Mono Methods

		private void Awake()
		{
			ChooseRandomAsteroidForm();
			this.health = new Health();
			//this.moveAlgorithm = new LinearMoveAlgorithm(this.transform, this.asteroidSettings.AsteroidLinearSpeed);
		}

        private void Update()
		{
			//moveAlgorithm.MovingBasedOnAlgorithm();
		}

		#endregion

		#region Public API

		public event Action<Asteroid, int, Vector3, GameObject[]> EventDie;

		/// <summary>
		/// Метод обработки cтолкновения
		/// </summary>
		/// <param name="damage">Урон от столкновения</param>
		public void GetCollision(int damage)
		{
			health.ReduceHealth(damage);

			if (health.HealthValue < 0)
			{
				GameObject particles = Instantiate(explosionFractionsPrefab, transform.position, Quaternion.identity);

				Destroy(particles, 1.0f);

				EventDie?.Invoke(this, pointsValue, transform.position, childAsteroids);

				Destroy(gameObject);
			}
		}

		#endregion

		#region Private Methods

		/// <summary>
		/// Метод случайным образом подключает слой Астероида определенной формы, отключает все остальные слои
		/// </summary>
		private void ChooseRandomAsteroidForm()
		{
			for (int i = 0; i < asteroidPieces.Length; i++)
			{
				GameObject asteroid = asteroidPieces[i];
				asteroid.SetActive(false);
			}

			GameObject chosenAsteroid = asteroidPieces[UnityEngine.Random.Range(0, asteroidPieces.Length)];
			chosenAsteroid.SetActive(true);
		}

		#endregion

	}
}
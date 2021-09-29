using UnityEngine;

namespace Assets.GameLogic.Scripts.ScriptableObjects
{
    [CreateAssetMenu(menuName = "GameEntitesEmitter/Settings", fileName = "GameEntitesEmitterData")]
    public class GameEntitesEmitterSettings : ScriptableObject
    {
		[SerializeField] private float offscreenPadding = 0.6f;
		[SerializeField] private int startingEntitiesCount = 2;

		/// <summary>
		/// Свойство задает отступ Эмиттера от углов экрана
		/// </summary>
		public float OffscreenPadding { get => this.offscreenPadding; }

		/// <summary>
		/// Свойство задает стартовое число Астероидов
		/// </summary>
		public int StartingEntitiesCount { get => this.startingEntitiesCount; }

		/// <summary>
		/// Свойство задает сторону экрана для старта Астероида
		/// </summary>
		public int StartingEntityScreenSide { get => Random.Range(0, 3); }

		/// <summary>
		/// Метод случайным образом вычисляет координаты для создаваемых Объектов
		/// </summary>
		/// <returns>Вектор в системе координат</returns>
		public Vector3 GetRandomOffScreenPosition()
		{
			float posX = 0.0f;
			float posY = 0.0f;
			
			switch (this.StartingEntityScreenSide)
			{
				// top
				case 0:
					posX = Random.value;
					posY = 0.0f;
					posY -= this.offscreenPadding;
					break;
				// bottom
				case 1:
					posX = Random.value;
					posY = 1.0f;
					posY += this.offscreenPadding;
					break;
				// left
				case 2:
					posX = 0.0f;
					posY = Random.value;
					posX -= this.offscreenPadding;
					break;
				// right
				case 3:
					posX = 1.0f;
					posY = Random.value;
					posX += this.offscreenPadding;
					break;
			}
			return Camera.main.ViewportToWorldPoint(new Vector3(posX, posY, 1.0f));
		}

		/// <summary>
		/// Метод случайным образом вычисляет углы вращения для создаваемых Объектов
		/// </summary>
		/// <returns>Углы вращения</returns>
		public Quaternion GetRandomOffScreenRotation()
		{
			int angle = 0;

			switch (this.StartingEntityScreenSide)
			{
				case 0:
					angle = Random.Range(20, 70);
					break;
				case 1:
					angle = -Random.Range(20, 70);
					break;
				case 2:
					angle = Random.Range(110, 160);
					break;
				case 3:
					angle = -Random.Range(110, 160);
					break;
				default:
					angle = Random.Range(1, 1);
					break;
			}
			return Quaternion.Euler(new Vector3(0.0f, 0.0f, angle));
		}

	}
}
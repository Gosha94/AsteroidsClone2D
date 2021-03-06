using UnityEngine;

namespace Assets.GameLogic.Scripts.GameEntities.GameBehaviours.Controllers
{

	/// <summary>
	/// Класс управляет объектами за пределами экрана
	/// </summary>
	public class BehindScreenBase : MonoBehaviour
	{

		[SerializeField] private float padding = 0.1f;

		private float top;
		private float bottom;
		private float left;
		private float right;

		protected bool isOffscreen;
		protected Vector3 viewportPos;

		public virtual void Awake()
		{
			top = 0.0f - padding;
			bottom = 1.0f + padding;
			left = 0.0f - padding;
			right = 1.0f + padding;
		}

		public virtual void Update()
		{
			viewportPos = Camera.main.WorldToViewportPoint(transform.position);
			isOffscreen = false;

			CheckXCoordinate();
			CheckYCoordinate();

		}

		/// <summary>
		/// Метод проверки выхода за пределы экрана по оси Y
		/// </summary>
		private void CheckXCoordinate()
		{
			if (viewportPos.x < left)
			{
				viewportPos.x = right;
				isOffscreen = true;
			}
			else if (viewportPos.x > right)
			{
				viewportPos.x = left;
				isOffscreen = true;
			}
		}

		/// <summary>
		/// Метод проверки выхода за пределы экрана по оси X
		/// </summary>
		private void CheckYCoordinate()
		{
			if (viewportPos.y < top)
			{
				viewportPos.y = bottom;
				isOffscreen = true;
			}
			else if (viewportPos.y > bottom)
			{
				viewportPos.y = top;
				isOffscreen = true;
			}
		}

	}
}
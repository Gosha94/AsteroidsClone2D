using System;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.GameLogic.Scripts.GameEntities.Views
{

	/// <summary>
	/// Класс описывает экран начала игры
	/// </summary>
    public class StartGameView : MonoBehaviour
    {
		#region Private Fields

		[SerializeField] private Text startText;

		private bool isComplete;

		#endregion

		#region Mono Methods

		private void OnEnable()
		{
			isComplete = false;
		}

		private void Update()
		{
			if (!isComplete)
			{
				if (Input.GetKeyDown(KeyCode.Space))
				{
					StartPressed();
				}
			}
		}

		#endregion

		#region Public API

		public event Action EventComplete;

		#endregion

		#region Private Methods

		private void StartPressed()
		{
			isComplete = true;

            EventComplete?.Invoke();
        }


		#endregion
	}
}

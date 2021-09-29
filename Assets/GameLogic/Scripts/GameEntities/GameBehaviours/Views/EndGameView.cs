using System;
using UnityEngine;
using UnityEngine.UI;
using Assets.GameLogic.Scripts.GameEntities.GameBehaviours.Controllers;

namespace Assets.GameLogic.Scripts.GameEntities.Views
{

    /// <summary>
    /// Класс описывает финальный игровой экран с общим счетом
    /// </summary>
    public class EndGameView : MonoBehaviour
    {

		#region Private Fields

		[SerializeField] private Text scoreValueText;

		private bool isComplete;

		#endregion

		#region Mono Methods

		void OnEnable()
		{
			isComplete = false;
			scoreValueText.text = ApplicationManagementService.Instance.MainGameScore.ToString();

			ApplicationManagementService.Instance.ResetGame();
		}

		void Update()
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

		public event Action EndGameEvent;

		#endregion

		#region Private Methods

		private void StartPressed()
		{

			isComplete = true;
			EndGameEvent?.Invoke();
		}

		#endregion

	}
}

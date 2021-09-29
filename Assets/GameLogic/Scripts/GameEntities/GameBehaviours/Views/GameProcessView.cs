using UnityEngine;
using UnityEngine.UI;
using Assets.GameLogic.Scripts.GameEntities.GameBehaviours.Controllers;

namespace Assets.GameLogic.Scripts.GameEntities.Views
{

    /// <summary>
    /// Класс описывает экран игрового процесса
    /// </summary>
    public class GameProcessView : MonoBehaviour
    {
		#region Private Fields

		private Text scoreText;

        #endregion

        #region Mono Methods

        private void Awake()
        {
			this.scoreText = GameObject.Find("ScoreNumber").GetComponent<Text>();
        }

		private void OnEnable()
		{
			ApplicationManagementService.Instance.StartGame();
		}

		#endregion

		#region Public Methods

		/// <summary>
		/// Метод обновляет счет в UI
		/// </summary>
		/// <param name="points">Кол-во очков для вывода в UI</param>
		public void UpdatePoints(int points)
		{
			scoreText.text = points.ToString();
		}

		/// <summary>
		/// Метод запускает логику отображения при старте уровня
		/// </summary>
		public void ShowLevelStart()
        {
			
		}

		#endregion

	}
}
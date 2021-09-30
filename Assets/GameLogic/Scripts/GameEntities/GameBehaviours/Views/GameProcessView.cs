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

		private Text scoreValue;
		private Text xCoordinateShipValue;
		private Text yCoordinateShipValue;
		private Text angleShipValue;
		private Text speedShipValue;
		private Text laserCountShipValue;
		private Text laserReloadShipTime;

		#endregion

		#region Mono Methods

		private void Awake()
        {
			this.scoreValue				= GameObject.Find("ScoreValue")			.GetComponent<Text>();
			this.xCoordinateShipValue	= GameObject.Find("XCoordValue")		.GetComponent<Text>();
			this.yCoordinateShipValue	= GameObject.Find("YCoordValue")		.GetComponent<Text>();
			this.angleShipValue			= GameObject.Find("GradusValue")		.GetComponent<Text>();
			this.speedShipValue			= GameObject.Find("SpeedValue")			.GetComponent<Text>();
			this.laserCountShipValue	= GameObject.Find("LaserCountValue")	.GetComponent<Text>();
			this.laserReloadShipTime	= GameObject.Find("LaserReloadValue")	.GetComponent<Text>();

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
			scoreValue.text = points.ToString();
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
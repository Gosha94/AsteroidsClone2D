using UnityEngine;
using UnityEngine.UI;
using Assets.GameLogic.Scripts.GameEntities.GameBehaviours.Controllers;
using Assets.GameLogic.Scripts.GameEntities.Models.Common;

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
		/// Метод обновляет данные игрока в UI
		/// </summary>
		/// <param name="data">Данные игрока</param>
		public void UpdatePlayerData(PlayerData receivedFromBackPlayerData)
        {
			this.xCoordinateShipValue.text	= receivedFromBackPlayerData.PlayerCoordinates.CoordinateX.ToString();
			this.yCoordinateShipValue.text	= receivedFromBackPlayerData.PlayerCoordinates.CoordinateY.ToString();
			this.angleShipValue.text		= receivedFromBackPlayerData.AngleShip.ToString();
			this.speedShipValue.text		= receivedFromBackPlayerData.SpeedShipValue.ToString();
			this.laserCountShipValue.text	= receivedFromBackPlayerData.LaserCountShip.ToString();
			this.laserReloadShipTime.text	= receivedFromBackPlayerData.LaserReloadShipTime.ToString();
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
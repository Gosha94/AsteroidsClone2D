using System;
using UnityEngine;


namespace Assets.GameLogic.Scripts.GameEntities.GameBehaviours.Controllers
{
    /// <summary>
    /// C����� ���������� �����������
    /// </summary>
    public class ApplicationManagementService : MonoBehaviour
    {
        #region Static Instance Property

        private static ApplicationManagementService instance;
        public static ApplicationManagementService Instance
        {
            get => instance;
        }

        #endregion

        #region Private Fields

        [SerializeField] private UiManagementService uiService;
        [SerializeField] private GameManagementService gameService;
        [SerializeField] private GameObject gameEnvironment;
        [SerializeField] private int startPlayerLives = 1;

        #endregion

        #region Public Properties

        /// <summary>
        /// �������� ��������� ���� �������� ������ ����
        /// </summary>
        public int MainGameScore { get; private set; }
        
        /// <summary>
        /// �������� ��������� ����� ������
        /// </summary>
        public int PlayerLives { get; private set; }

        #endregion

        #region Public API

        /// <summary>
        /// ����� ����
        /// </summary>
        public void StartGame()
        {
            gameEnvironment.SetActive(true);

            ResetGame();

            gameService.StartLevel();
            gameService.SpawnPlayer();
        }

        /// <summary>
        /// ����� ����
        /// </summary>
        public void ResetGame()
        {
            this.MainGameScore = 0;
            this.PlayerLives = startPlayerLives;
            gameService.Reset();
            uiService.UpdatePoints(this.MainGameScore);
        }

        #endregion

        #region Mono Methods

        void Awake()
        {
            if (instance == null)
            {
                instance = this;
            }
            else if (instance != this)
            {
                Destroy(gameObject);
            }

            DontDestroyOnLoad(gameObject);

            gameEnvironment.SetActive(false);

            gameService.IncreaseScoreEvent += OnLevelPoints;
            gameService.PlayerDiedEvent += OnLevelFailed;
            gameService.GameStartedEvent += OnLevelStarted;
        }

        void Start()
        {
            uiService.ShowStartingView(true);
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// ����� ���������� ��� ��������� ����� � ����
        /// </summary>
        /// <param name="points">����, ���������� �� ����������� ������� ��������</param>
        private void OnLevelPoints(int points)
        {
            this.MainGameScore += points;
            uiService.UpdatePoints(this.MainGameScore);
        }
        

        private void OnLevelFailed()
        {
            this.PlayerLives--;

            if (this.PlayerLives > 0)
            {
                gameService.SpawnPlayer();
            }
            else
            {
                uiService.ShowScoreView();
            }
        }
        
        /// <summary>
        /// ����� ��������� ������� ����� ����
        /// </summary>
        private void OnLevelStarted()
        {
            uiService.ShowLevelStart();
        }

        #endregion

    }
}
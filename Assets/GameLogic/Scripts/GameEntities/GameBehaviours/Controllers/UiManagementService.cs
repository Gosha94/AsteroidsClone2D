using Assets.GameLogic.Scripts.GameEntities.Views;
using UnityEngine;

namespace Assets.GameLogic.Scripts.GameEntities.GameBehaviours.Controllers
{
	public class UiManagementService : MonoBehaviour
	{
		[SerializeField] private StartGameView		startGameView;
		[SerializeField] private GameProcessView	gameProcessView;
		[SerializeField] private EndGameView		endGameView;
		[SerializeField] private RectTransform		transitionOverlay;

		private GameObject currentView;

		#region Mono Methods

		void Awake()
		{
			startGameView.EventComplete += OnTitleViewComplete;
			endGameView.EndGameEvent += OnScoreViewComplete;
		}

		#endregion

		#region Public Methods

		public void ShowStartingView(bool firstTime = false)
		{
			if (firstTime)
			{
				currentView = startGameView.gameObject;
				startGameView.gameObject.SetActive(true);
				FadeOutOverlay();
			}
			else
			{
				TransitionScreen(startGameView.gameObject);
			}
		}

		public void ShowGameProcessView()
		{
			TransitionScreen(gameProcessView.gameObject);
		}

		public void ShowScoreView()
		{
			TransitionScreen(endGameView.gameObject);
		}

		public void UpdatePoints(int points)
		{
			gameProcessView.UpdatePoints(points);
		}

		public void ShowLevelStart()
		{
			gameProcessView.ShowLevelStart();
		}

		#endregion

		#region Private Methods

		private void FadeOutOverlay()
			=> transitionOverlay.gameObject.SetActive(false);

		private void TransitionScreen(GameObject screen)
		{
			transitionOverlay.gameObject.SetActive(true);

			screen.SetActive(true);
			
			if (currentView != null)
			{
				currentView.SetActive(false);
			}

			currentView = screen;					
			transitionOverlay.gameObject.SetActive(false);

		}
		
		private void OnTitleViewComplete()
			=> ShowGameProcessView();
		
		private void OnGameViewComplete()
			=> ShowScoreView();

		
		private void OnScoreViewComplete()
			=> ShowStartingView();


		#endregion

	}
}

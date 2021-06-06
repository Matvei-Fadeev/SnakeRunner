using DG.Tweening;
using UnityEngine;

namespace Managers.UI {
	public class UIManager : MonoBehaviour {
		[Header("Depended objects")]
		[SerializeField] private GameScreen[] screens;

		[Header("Configuration")]
		[SerializeField] private float moveDuration;

		private GameScreen _currentGameScreen;
		private Vector3 _centerPosition;
		private Vector3 _positionToHide;
		private Vector3 _positionToShow;

		private void Awake() {
			foreach (var screen in screens) {
				HideScreen(screen.panel.transform);
			}

			if (screens.Length > 0) {
				_currentGameScreen = screens[0];
			}

			CalculatePosition();
		}

		public void SwitchScreen(GameCommands gameCommands) {
			foreach (var screen in screens) {
				if (screen.gameCommands == gameCommands) {
					HideScreen(_currentGameScreen.panel.transform);
					_currentGameScreen = screen;
					ShowScreen(_currentGameScreen.panel.transform);
					break;
				}
			}
		}

		private void CalculatePosition() {
			_centerPosition = new Vector3(Screen.width / 2, Screen.height / 2, 10);
			_positionToHide = _centerPosition + Vector3.right * Screen.width;
			_positionToShow = _centerPosition + Vector3.left * Screen.width * 2;
		}

		private void ShowScreen(Transform panelTransform) {
			panelTransform.gameObject.SetActive(true);
			panelTransform.DOMove(_positionToShow, 0f);
			panelTransform.DOMove(_centerPosition, moveDuration);
		}

		private void HideScreen(Transform panelTransform) {
			panelTransform.DOMove(_positionToHide, moveDuration);
		}
	}
}
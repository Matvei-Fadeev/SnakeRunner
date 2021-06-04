using System;
using DG.Tweening;
using UnityEngine;

namespace Core.Managers.UI {
	public class UIManager : MonoBehaviour {
		[Header("Depended objects")]
		[SerializeField] private GameScreen[] screens;

		[Header("Configuration")]
		[SerializeField] private float moveDuration;

		[SerializeField] private GameCommands startedCommand;

		private GameScreen _currentGameScreen;
		private Vector3 _centerPosition;
		private Vector3 _positionToHide;
		private Vector3 _positionToShow;

		private void Awake() {
			foreach (var screen in screens) {
				if (screen.gameCommands == startedCommand) {
					_currentGameScreen = screen;
				}
				else {
					HideScreen(screen.panel.transform);
				}
			}

			if (_currentGameScreen.Equals(null)) {
				Debug.LogError("Set the startedCommand");
			}
		}

		private void Start() {
			_centerPosition = new Vector3(Screen.width / 2, Screen.height / 2, 10);
			
			// Go to left from current screen view
			_positionToHide = _centerPosition + Vector3.left * Screen.width;
			
			// Come from right from current screen view
			_positionToShow = _centerPosition + Vector3.right * Screen.width * 2;
		}

		public void SwitchScreen(GameCommands gameCommands) {
			foreach (var screen in screens) {
				if (screen.gameCommands == gameCommands) {
					HideScreen(_currentGameScreen.panel.transform);
					_currentGameScreen = screen;
					ShowScreen(_currentGameScreen.panel.transform);
				}
			}
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
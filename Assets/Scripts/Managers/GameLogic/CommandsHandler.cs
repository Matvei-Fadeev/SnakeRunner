using System;
using CameraUtility;
using Data.Resource;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Managers.GameLogic {
	public class CommandsHandler {
		public void HandleState(GameCommands gameCommand) {
			switch (gameCommand) {
				case GameCommands.GamePlay:
					break;
				case GameCommands.GameWin:
				case GameCommands.GameOver:
					CameraFreezeMovement(true);
					break;
				case GameCommands.Restart:
					Restart();
					break;
				default:
					throw new ArgumentOutOfRangeException(nameof(gameCommand));
			}
		}

		private void CameraFreezeMovement(bool hasFreezing) {
			UnityEngine.Camera camera = UnityEngine.Camera.main;
			if (camera && camera.TryGetComponent(out CameraFollow cameraFollow)) {
				cameraFollow.hasFreezeMovement = hasFreezing;
			}
		}

		private static void Restart() {
			ResourceHolder.Reset();
			// Reload current scene
			SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex);
		}
	}
}
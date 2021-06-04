using System;
using Camera;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Managers.GameLogic {
	public class CommandsHandler {
		public void HandleState(GameCommands gameCommand) {
			switch (gameCommand) {
				case GameCommands.GamePlay:
					CameraFreezeMovement(false);
					break;
				case GameCommands.GameWin:
				case GameCommands.GameOver:
					CameraFreezeMovement(true);
					break;
				case GameCommands.Restart:
					SceneReload();
					break;
				default:
					Debug.Log(gameCommand);
					throw new ArgumentOutOfRangeException(nameof(gameCommand));
			}
		}

		private void CameraFreezeMovement(bool hasFreezing) {
			UnityEngine.Camera camera = UnityEngine.Camera.main;
			if (camera && camera.TryGetComponent(out CameraFollow cameraFollow)) {
				cameraFollow.hasFreezeMovement = hasFreezing;
			}
		}

		private static void SceneReload() {
			SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex);
		}
	}
}
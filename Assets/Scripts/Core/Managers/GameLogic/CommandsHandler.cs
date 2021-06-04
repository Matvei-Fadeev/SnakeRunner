using System;
using Camera;
using UnityEngine.SceneManagement;
using Camera = UnityEngine.Camera;

namespace Core.Managers.GameLogic {
	public class CommandsHandler {
		public void HandleState(GameCommands gameCommands) {
			switch (gameCommands) {
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
					throw new ArgumentOutOfRangeException(nameof(gameCommands), gameCommands, null);
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
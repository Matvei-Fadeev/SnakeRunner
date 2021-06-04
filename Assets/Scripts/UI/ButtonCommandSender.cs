using System;
using Managers;
using UnityEngine;
using UnityEngine.UI;

namespace UI {
	public class ButtonCommandSender : MonoBehaviour {
		public static Action<GameCommands> SentCommand;
		
		[SerializeField] private GameCommands gameCommands;

		private Button _button;
		
		private void Awake() {
			if (TryGetComponent(out Button button)) {
				_button = button;
			}
			else {
				gameObject.AddComponent<Button>();
			}
		}

		private void OnEnable() {
			_button.onClick.AddListener(SendCommand);
		}

		private void OnDisable() {
			_button.onClick.RemoveListener(SendCommand);
		}

		private void SendCommand() {
			if (gameCommands == GameCommands.None) {
				throw new UnityException("Set the command to the button");
			}
			SentCommand?.Invoke(gameCommands);
		}
	}
}
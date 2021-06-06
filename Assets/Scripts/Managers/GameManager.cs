using Managers.GameLogic;
using Managers.UI;
using UI;
using UnityEngine;

namespace Managers {
	public class GameManager : MonoBehaviour {
		[Header("Dependent objects")]
		[SerializeField] private UIManager uiManager;
		[SerializeField] private Core.Player.PlayerDeath playerDeath;

		[Header("Configuration")]
		[SerializeField] private GameCommands startedCommand;

		private CommandsHandler _commandsHandler;

		private void Awake() {
			_commandsHandler = new CommandsHandler();
		}

		private void OnEnable() {
			playerDeath.PlayerState += HandleState;
			ButtonCommandSender.SentCommand += HandleState;
		}

		private void Start() {
			HandleState(startedCommand);
		}

		private void OnDisable() {
			playerDeath.PlayerState -= HandleState;
			ButtonCommandSender.SentCommand -= HandleState;
		}

		private void HandleState(GameCommands gameCommands) {
			_commandsHandler.HandleState(gameCommands);
			uiManager.SwitchScreen(gameCommands);
		}
	}
}
using Core.Managers.GameLogic;
using Core.Managers.UI;
using UI;
using UnityEngine;

namespace Core.Managers {
	public class GameManager : MonoBehaviour {
		[Header("Dependent objects")]
		[SerializeField] private UIManager uiManager;
		[SerializeField] private Player.PlayerDeath playerDeath;
		
		private CommandsHandler _commandsHandler;

		private void Awake() {
			_commandsHandler = new CommandsHandler();
		}

		private void OnEnable() {
			playerDeath.PlayerState += HandleState;
			ButtonCommandSender.SentCommand += HandleState;
		}

		private void Start() {
			HandleState(GameCommands.GamePlay);
		}

		private void OnDisable() {
			playerDeath.PlayerState -= HandleState;
			ButtonCommandSender.SentCommand -= HandleState;

		}

		private void HandleState(GameCommands gameCommands) {
			Debug.Log($"HandleState {gameCommands}");
			_commandsHandler.HandleState(gameCommands);
			uiManager.SwitchScreen(gameCommands);
		}

		public void SomeString(GameCommands qwe) {
			
		}
	}
}
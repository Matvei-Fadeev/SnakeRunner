using System;

namespace Managers {
	[Serializable]
	public enum GameCommands {
		None,
		GamePlay,
		GameWin,
		GameOver,
		Restart
	}
}
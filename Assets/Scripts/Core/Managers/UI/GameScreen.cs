using System;
using UnityEngine;

namespace Core.Managers.UI {
	[Serializable]
	public struct GameScreen {
		public CanvasRenderer panel;
		public GameCommands gameCommands;
	}
}
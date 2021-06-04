using System;
using UnityEngine;

namespace Managers.UI {
	[Serializable]
	public struct GameScreen {
		public CanvasRenderer panel;
		public GameCommands gameCommands;
	}
}
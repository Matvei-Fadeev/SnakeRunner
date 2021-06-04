using UnityEngine;

namespace Input {
	// The singleton abstract class which realise the input from player or etc.
	public abstract class InputHandler : MonoBehaviour {
		private static InputHandler _instance;
		public static InputHandler Instance => _instance;

		protected void Awake() {
			InitInstance();
		}

		private void InitInstance() {
			if (_instance != null && _instance != this) {
				throw new UnityException($"Have 2 singleton on the scene {this.name} and {_instance.name}");
			}

			_instance = this;
		}

		/// <returns>The input direction</returns>
		public abstract Vector2 GetDirection();
		
		/// <returns>The float direction. The negative is down. The positive is up.</returns>
		public abstract float GetVertical();
		
		/// <returns>The float direction. The negative is left. The positive is right.</returns>
		public abstract float GetHorizontal();
	}
}
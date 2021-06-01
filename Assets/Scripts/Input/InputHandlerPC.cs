using UnityEngine;

namespace Input {
	public class InputHandlerPC : InputHandler {
		public override float GetHorizontal() {
			return UnityEngine.Input.GetAxis("Horizontal");
		}

		public override float GetVertical() {
			return UnityEngine.Input.GetAxis("Vertical");
		}

		public override Vector2 GetDirection() {
			Vector2 direction = new Vector2(GetHorizontal(), GetVertical());
			return direction;
		}
	}
}
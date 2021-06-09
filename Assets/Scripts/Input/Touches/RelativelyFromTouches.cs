using UnityEngine;

namespace Input.Touches {
	public class RelativelyFromTouches : InputHandler {
		public float sensitivity = 14f;
		private Vector2 _screenSize;

		private void Start() {
			_screenSize = new Vector2(Screen.width, Screen.height);
		}

		public override Vector2 GetDirection() {
			if (UnityEngine.Input.touchCount > 0) {
				Touch touch = UnityEngine.Input.GetTouch(0);
				var direction = (touch.deltaPosition / _screenSize) * sensitivity;
				return direction;
			}

			return Vector2.zero;
		}

		public override float GetVertical() {
			return GetDirection().y;
		}

		public override float GetHorizontal() {
			return GetDirection().x;
		}
	}
}
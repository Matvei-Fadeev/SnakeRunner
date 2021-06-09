using UnityEngine;

namespace Input.Touches.Target {
	class FromTargetToTouchedWorldPoint : TargetInputHandler {
		private Vector3 _lastDirection;
		private Vector3 _positionToMove;
		
		public override Vector2 GetDirection() {
			var directionToMove = Vector3.zero;

			if (UnityEngine.Input.touchCount > 0) {
				var touch = UnityEngine.Input.GetTouch(0);
				if (touch.phase == TouchPhase.Stationary) {
					directionToMove = _lastDirection;
				}
				else if (touch.phase == TouchPhase.Moved) {
					Ray ray = Camera.ScreenPointToRay(touch.position);
					if (Physics.Raycast(ray, out var hitInfo, 100)) {
						_positionToMove = hitInfo.point;

						directionToMove = _positionToMove - Target.position;
						if (useNormalizedDirection) {
							directionToMove = directionToMove.normalized;
						}

						_lastDirection = directionToMove;
					}
				}
			}

			return directionToMove;
		}
	}
}
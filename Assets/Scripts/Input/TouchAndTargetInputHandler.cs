using UnityEngine;

namespace Input {
	public class TouchAndTargetInputHandler : InputHandler {
		[Header("Target to calculate direction")]
		[SerializeField] private string targetTag = "Player";

		[Tooltip("Direction is normilized and independent from distance between target and touch position")]
		[SerializeField] private bool useNormalizedDirection = true;

		private Transform _target;
		private UnityEngine.Camera _camera;
		private Vector3 _lastDirection;
		private Vector3 _positionToMove;

		protected new void Awake() {
			base.Awake();
			
			_target = GameObject.FindGameObjectWithTag(targetTag).transform;
			_camera = UnityEngine.Camera.main;
		}

		public override Vector2 GetDirection() {
			var directionToMove = Vector3.zero;

			if (UnityEngine.Input.touchCount > 0) {
				var touch = UnityEngine.Input.GetTouch(0);
				if (touch.phase == TouchPhase.Stationary) {
					directionToMove = _lastDirection;
				}
				else if (touch.phase == TouchPhase.Moved) {
					Ray ray = _camera.ScreenPointToRay(touch.position);
					if (Physics.Raycast(ray, out var hitInfo, 100)) {
						_positionToMove = hitInfo.point;

						directionToMove = _positionToMove - _target.position;
						if (useNormalizedDirection) {
							directionToMove = directionToMove.normalized;
						}

						_lastDirection = directionToMove;
					}
				}
			}

			return directionToMove;
		}

		public override float GetVertical() {
			return GetDirection().y;
		}

		public override float GetHorizontal() {
			return GetDirection().x;
		}
	}
}
using Input;
using UnityEngine;

namespace Core.Movement {
	public class MovementController : MonoBehaviour {
		public float forwardSpeed = 1f;
		public float horizontalSpeed = 1f;

		private Rigidbody _rigidbody;

		private void Awake() {
			_rigidbody = GetComponent<Rigidbody>();
		}

		private void Update() {
			Move();
		}

		private void Move() {
			var direction = transform.forward * forwardSpeed;
			direction.x = InputHandler.Instance.GetHorizontal() * horizontalSpeed;
			MoveToDirection(direction);
		}

		private void MoveToDirection(Vector3 direction) {
			_rigidbody.velocity = direction;
		}
	}
}
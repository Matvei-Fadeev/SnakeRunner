using Input;
using UnityEngine;

namespace Core.Movement {
	public class MovementController : MonoBehaviour {
		[Header("Configuration")] 
		[SerializeField] private float forwardSpeed = 1f;
		[SerializeField] private float horizontalSpeed = 1f;
		
		[Header("Input configuration")]
		[SerializeField] private bool hasLockInput;
		
		private Rigidbody _rigidbody;
		private float inputValueWhenLocked = 0f;

		public float ForwardSpeed {
			get => forwardSpeed;
			set => forwardSpeed = value;
		}

		public bool HasLockInput {
			get => hasLockInput;
			set => hasLockInput = value;
		}

		private void Awake() {
			_rigidbody = GetComponent<Rigidbody>();
		}

		private void Update() {
			Move();
		}

		private void Move() {
			var direction = transform.forward * forwardSpeed;
			var horizontalInput = !hasLockInput ? InputHandler.Instance.GetHorizontal() : inputValueWhenLocked;
			var rotationInput = horizontalInput * horizontalSpeed;
			direction.x = rotationInput;
			MoveToDirection(direction);
		}

		private void MoveToDirection(Vector3 direction) {
			_rigidbody.velocity = direction;
		}
	}
}
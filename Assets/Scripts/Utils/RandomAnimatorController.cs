using UnityEngine;

namespace Utils {
	public class RandomAnimatorController : MonoBehaviour {
		public RuntimeAnimatorController[] animatorControllers;
		private Animator _animator;

		private void Awake() {
			_animator = GetComponent<Animator>();
		}

		private void Start() {
			_animator.runtimeAnimatorController = animatorControllers[Random.Range(0, animatorControllers.Length)];
		}
	}
}
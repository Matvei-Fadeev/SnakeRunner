using Core.Animations;
using UnityEngine;

namespace Core.GameObjects {
	public class PlayerTriggerAnimations : MonoBehaviour {
		[SerializeField] private string playerTag = "Player";

		private IAnimations[] _animations;

		private void Awake() {
			_animations = GetComponents<IAnimations>();
		}

		private void OnTriggerEnter(Collider player) {
			if (player.CompareTag(playerTag)) {
				var playerPosition = player.transform.position;
				foreach (var animation in _animations) {
					animation.Show(playerPosition);
				}
			}
		}
	}
}
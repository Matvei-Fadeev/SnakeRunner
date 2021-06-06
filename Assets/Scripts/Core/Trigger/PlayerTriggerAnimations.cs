using Animations;
using UnityEngine;

namespace Core.Trigger {
	public class PlayerTriggerAnimations : PlayerInTrigger {	
		private IAnimation[] _animations;

		private void Awake() {
			_animations = GetComponents<IAnimation>();
		}

		protected override void Action(GameObject player) {
			var playerPosition = player.transform.position;
			foreach (var animation in _animations) {
				animation.Show(playerPosition);
			}
		}
	}
}
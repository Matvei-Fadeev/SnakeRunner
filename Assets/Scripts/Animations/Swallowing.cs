using DG.Tweening;
using UnityEngine;

namespace Animations {
	public class Swallowing : MonoBehaviour, IAnimation {
		[SerializeField] private float duration = 0.2f;
		[SerializeField] private Vector3 finalRotation;

		public void Show(Vector3 currentPosition) {
			StartSwallowing(currentPosition);
		}

		private void StartSwallowing(Vector3 player) {
			transform.DOMoveX(player.x, duration);
			transform.DOScale(Vector3.zero, duration);
			transform.DORotate(finalRotation, duration);
		}
	}
}
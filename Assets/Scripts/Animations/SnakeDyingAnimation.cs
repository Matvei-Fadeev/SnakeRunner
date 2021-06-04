using DG.Tweening;
using UnityEngine;

namespace Animations {
	class SnakeDyingAnimation : MonoBehaviour, IAnimation {
		[SerializeField] private float jumpHeight = 10f;
		[SerializeField] private float jumpDuration = 4f;
		[SerializeField] private Vector3 jumpOffset = new Vector3(10, -10, 0);

		public void Show(Vector3 currentPosition) {
			DyingAnimation(currentPosition);
		}

		private void DyingAnimation(Vector3 position) {
			Vector3 underPlanePosition = position + jumpOffset ;
			transform.DOJump(underPlanePosition, jumpHeight, 1, jumpDuration, false);
		}
	}
}
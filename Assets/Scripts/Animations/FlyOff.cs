using DG.Tweening;
using UnityEngine;

namespace Animations {
	public class FlyOff : MonoBehaviour, IAnimation {
		[SerializeField] private float jumpHeight = 10f;
		[SerializeField] private float jumpDuration = 3f;
		[SerializeField] private Vector3 jumpOffset = new Vector3(14, -10, 0);

		public void Show(Vector3 currentPosition) {
			DyingAnimation(currentPosition);
		}

		private void DyingAnimation(Vector3 position) {
			Vector3 underPlanePosition = position + jumpOffset ;
			transform.DOJump(underPlanePosition, jumpHeight, 1, jumpDuration, false);
		}
	}
}
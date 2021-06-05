using DG.Tweening;
using UnityEngine;

namespace Camera {
	public class CameraIntro : MonoBehaviour {
		[Header("Configuration")]
		[SerializeField] private float startDurationToMoving;

		[SerializeField] private Vector3 positionToMove;
		
		private CameraFollow _cameraFollow;
		private bool defaultFreezeMovement;

		private void Awake() {
			if (TryGetComponent(out CameraFollow cameraFollow)) {
				_cameraFollow = cameraFollow;
				defaultFreezeMovement = _cameraFollow.hasFreezeMovement;
				_cameraFollow.hasFreezeMovement = true;
			}
		}

		private void Start() {

			Sequence sequence = DOTween.Sequence();
			sequence
				.Append(transform.DOMove(positionToMove, startDurationToMoving))
				.OnComplete(StopCameraFreezing);

			sequence.Play();
			//transform.DOMove(target, startDurationToMoving)

		}

		private void StopCameraFreezing() {
			if (_cameraFollow) {
				_cameraFollow.hasFreezeMovement = defaultFreezeMovement;
			}
		}
	}
}
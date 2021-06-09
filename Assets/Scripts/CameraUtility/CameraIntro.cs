using DG.Tweening;
using UnityEngine;

namespace CameraUtility {
	public class CameraIntro : MonoBehaviour {
		[Header("Configuration")]
		[SerializeField] private float durationMovingToTarget;
		[SerializeField] private Transform target;

		private CameraFollow _cameraFollow;
		private bool _defaultFreezeMovement;
		private Transform _defaultParent;

		private void Awake() {
			if (TryGetComponent(out CameraFollow cameraFollow)) {
				_cameraFollow = cameraFollow;
				_defaultFreezeMovement = _cameraFollow.hasFreezeMovement;
			}
			else {
				Debug.LogError($"Set the Camera follow to the {typeof(CameraIntro)}");
			}

			_defaultParent = transform.parent;
		}

		private void Start() {
			MovingToTarget();
		}

		private void MovingToTarget() {
			_cameraFollow.hasFreezeMovement = true;
			transform.SetParent(target);
			transform.DOLocalMove(_cameraFollow.OffsetFromTarget, durationMovingToTarget).OnComplete(StopCameraFreezing);
		}

		private void StopCameraFreezing() {
			_cameraFollow.hasFreezeMovement = _defaultFreezeMovement;
			transform.SetParent(_defaultParent);
		}
	}
}
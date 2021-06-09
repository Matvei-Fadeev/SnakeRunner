using DG.Tweening;
using UnityEngine;

namespace Animations {
	public class CrystalAnimation : MonoBehaviour, IAnimation {
		[SerializeField] private bool isAnimated = false;

		[SerializeField] private bool isRotating = false;
		[SerializeField] private bool isScaling = false;

		[SerializeField] private Vector3 rotation;
		[SerializeField] private float rotationDuration;
		
		[SerializeField] private Vector3 endScale;
		[SerializeField] private float scaleDuration;
		
		private Vector3 startScale;

		private void Start() {
			Show(transform.position);
		}

		public void Show(Vector3 currentPosition) {
			Show();
		}

		private void Show() {
			Sequence sequence = DOTween.Sequence();
			startScale = transform.localScale;
			var rotationBeyond = transform.rotation.eulerAngles + rotation;
			
			sequence
				.Append(transform.DORotate(rotationBeyond, rotationDuration))
				.Insert(0,transform.DOScale(endScale, scaleDuration))
				.Insert(scaleDuration,transform.DOScale(startScale, scaleDuration))
				.SetLoops(-1);

			sequence.Play();
		}
	}
}
using DG.Tweening;
using UnityEngine;

namespace Animations {
	public class PopupScore : MonoBehaviour, IAnimation {
		[Header("Prefab to spawn")]
		[SerializeField] private GameObject popupScorePrefab;

		[Header("Configuration")]
		[SerializeField] private Vector3 popupOffsetFromTarget = new Vector3(0, 1, 0);
		[SerializeField] private Vector3 popupRotation = new Vector3(45, 0, 0);
		[SerializeField] private float scaleDuration = 0.5f;

		private Transform _parent;
		private GameObject _popup;

		private void Awake() {
			if (!_popup) {
				_popup = Instantiate(popupScorePrefab, transform, false);
				_parent = _popup.transform.parent;
			}
			SetNotActive();
		}

		public void Show(Vector3 currentPosition) {
			ShowPopupScore(currentPosition);
		}

		private void ShowPopupScore(Vector3 position) {
			SetActive();
			Transform popup = _popup.transform;
			Sequence _mySequence = DOTween.Sequence();
			_mySequence
				.Append(popup.DOMove(position + popupOffsetFromTarget, 0f))
				.Append(popup.DOScale(Vector3.zero, 0f))
				.Append(popup.DORotate(popupRotation, 0f))
				.Append(popup.DOScale(Vector3.one, scaleDuration))
				.OnComplete(SetNotActive);

			_mySequence.Play();
		}

		private void SetActive() {
			_popup.transform.SetParent(null);
			_popup.SetActive(true);
		}

		private void SetNotActive() {
			_popup.transform.SetParent(_parent);
			_popup.SetActive(false);
		}
	}
}
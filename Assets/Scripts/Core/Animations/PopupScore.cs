using System;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

namespace Core.Animations {
	public class PopupScore : MonoBehaviour, IAnimation {
		[Header("Prefab to spawn")]
		[SerializeField] private GameObject popupScorePrefab;

		[Header("Configuration")]
		[SerializeField] private Vector3 popupOffsetFromTarget = new Vector3(0, 1, 0);

		[SerializeField] private Vector3 popupRotation = new Vector3(45, 0, 0);
		[SerializeField] private float scaleDuration = 0.5f;

		private const int CountOfPopups = 10;
		private int currentPopUp = 0;
		private Vector3 invisiblePosition = new Vector3(-999, -999, -999);
		private List<GameObject> _popupScores;

		private void Awake() {
			_popupScores = new List<GameObject>(CountOfPopups);
			for (int i = 0; i < CountOfPopups; i++) {
				var popup = Instantiate(popupScorePrefab, invisiblePosition, default);
				_popupScores.Add(popup);
			}
		}

		public void Show(Vector3 position) {
			ShowPopupScore(position);
		}

		private void ShowPopupScore(Vector3 position) {
			int index = currentPopUp % CountOfPopups;
			Transform popup = _popupScores[index].transform;
			Sequence _mySequence = DOTween.Sequence();
			_mySequence
				.Append(popup.DOMove(position + popupOffsetFromTarget, 0f))
				.Append(popup.DOScale(Vector3.zero, 0f))
				.Append(popup.DORotate(popupRotation, 0f))
				.Append(popup.DOScale(Vector3.one, scaleDuration))
				.Append(popup.DOMove(invisiblePosition, 0f));

			_mySequence.Play();
		}
	}
}
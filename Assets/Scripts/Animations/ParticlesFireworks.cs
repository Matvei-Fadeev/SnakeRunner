using DG.Tweening;
using UnityEngine;

namespace Animations {
	class ParticlesFireworks : MonoBehaviour ,IAnimation {
		[Header("Spawned GameObject")]
		[SerializeField] private GameObject particleSystemPrefab;

		[Header("Configuration")]
		[SerializeField] private float fireworksDuration = 0.2f;

		private GameObject _particleSystemTransform;

		private void Awake() {
			_particleSystemTransform = Instantiate(particleSystemPrefab);
			SetNotActive();
		}

		public void Show(Vector3 currentPosition) {
			_particleSystemTransform.SetActive(true);
			Sequence mySequence = DOTween.Sequence();
			mySequence
				.Append(_particleSystemTransform.transform.DOMove(currentPosition, 0f))
				.AppendInterval(fireworksDuration)
				.OnComplete(SetNotActive);
			
			mySequence.Play();
		}

		private void SetNotActive() {
			_particleSystemTransform.gameObject.SetActive(false);
		}
	}
}
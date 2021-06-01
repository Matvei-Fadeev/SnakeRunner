using DG.Tweening;
using UnityEngine;

namespace Core.Animations {
	public class Swallowing : MonoBehaviour {
		[SerializeField] private string playerTag = "Player";
		[SerializeField] private float duration = 0.2f;
		[SerializeField] private Vector3 finalRotation;
		
		private void OnTriggerEnter(Collider player) {
			if (player.CompareTag(playerTag)) {
				StartSwallowing(player.gameObject);
			}
		}

		private void StartSwallowing(GameObject player) {
			transform.DOMoveX(transform.position.x, duration);
			transform.DOScale(Vector3.zero, duration);
			transform.DORotate(finalRotation, duration);
		}
	}
}
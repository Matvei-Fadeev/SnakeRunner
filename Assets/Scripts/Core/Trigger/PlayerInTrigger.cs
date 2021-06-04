using UnityEngine;

namespace Core.Trigger {
	public abstract class PlayerInTrigger : MonoBehaviour {
		[SerializeField] protected string playerTag = "Player";

		private void OnTriggerEnter(Collider other) {
			if (other.CompareTag(playerTag)) {
				Action(other.gameObject);
			}
		}

		protected abstract void Action(GameObject player);
	}
}
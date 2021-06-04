using System;
using Animations;
using Core.Player.DeathCheckers;
using Managers;
using UnityEngine;

namespace Core.Player {
	[ExecuteInEditMode]
	public class PlayerDeath : MonoBehaviour {
		public Action<GameCommands> PlayerState;
		
		[Header("Animations")]
		[SerializeField] private bool enableDyingAnimation = true;

		private Checker[] dyingCheckers;
		private IAnimation dyingAnimation;

		private void Awake() {
			dyingCheckers = GetComponentsInChildren<Checker>();
			dyingAnimation = GetComponent<IAnimation>();
		}

		private void OnEnable() {
			SubscribeToCheckers();
		}

		private void OnDisable() {
			UnsubscribeFromCheckers();
		}

		private void PlayerDying() {
			PlayerState?.Invoke(GameCommands.GameOver);
			TurnOffRigidbody();
			if (enableDyingAnimation) {
				dyingAnimation.Show(transform.position);
			}
		}

		private void TurnOffRigidbody() {
			if (TryGetComponent(out Rigidbody rigidbody)) {
				rigidbody.detectCollisions = false;
			}
		}

		private void SubscribeToCheckers() {
			foreach (Checker checker in dyingCheckers) {
				checker.IsDying += PlayerDying;
			}
		}

		private void UnsubscribeFromCheckers() {
			foreach (Checker checker in dyingCheckers) {
				checker.IsDying -= PlayerDying;
			}
		}
	}
}
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
		
		[Header("Configuration")]
		[SerializeField] private bool hasInvulnerability;

		private Checker[] _dyingCheckers;
		private IAnimation _dyingAnimation;

		public bool HasInvulnerability {
			get => hasInvulnerability;
			set => hasInvulnerability = value;
		}

		private void Awake() {
			_dyingCheckers = GetComponentsInChildren<Checker>();
			_dyingAnimation = GetComponent<IAnimation>();
		}

		private void OnEnable() {
			SubscribeToCheckers();
		}

		private void OnDisable() {
			UnsubscribeFromCheckers();
		}

		private void PlayerDying() {
			if (!hasInvulnerability) {
				PlayerState?.Invoke(GameCommands.GameOver);
				TurnOffRigidbody();
				if (enableDyingAnimation) {
					_dyingAnimation.Show(transform.position);
				}
			}
		}

		private void TurnOffRigidbody() {
			if (TryGetComponent(out Rigidbody rigidbody)) {
				rigidbody.detectCollisions = false;
			}
		}

		private void SubscribeToCheckers() {
			foreach (Checker checker in _dyingCheckers) {
				checker.IsDying += PlayerDying;
			}
		}

		private void UnsubscribeFromCheckers() {
			foreach (Checker checker in _dyingCheckers) {
				checker.IsDying -= PlayerDying;
			}
		}
	}
}
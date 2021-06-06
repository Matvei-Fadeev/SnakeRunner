using Core.Movement;
using Data.Resource;
using DG.Tweening;
using UnityEngine;

namespace Core.Player {
	public class Fever : MonoBehaviour {
		[Header("Configuration of fever")]
		[SerializeField] private float feverTime = 5f;
		[SerializeField] private float speedMultiplier = 3f;
		[SerializeField] private float feverXAxisPosition = 0;
		[SerializeField] private float durationToSetFeverPosition = 1f;
		
		[Header("Configuration of crystals")]
		[SerializeField] private bool hasResetCrystalsAfterFever = true;
		[SerializeField] private int maxCountOfCrystals = 30;

		private int _amountOfCrystalsAtLastFever;
		private bool _hasFever;
		private MovementController _movementController;
		private PlayerDeath _playerDeath;

		private void Awake() {
			_movementController = GetComponent<MovementController>();
			TryGetComponent(out _playerDeath);
		}

		private void Start() {
			SaveAmountOfCrystals();
		}

		private void FixedUpdate() {
			if (!_hasFever && ResourceHolder.Crystals > maxCountOfCrystals + _amountOfCrystalsAtLastFever) {
				StartFever();
				Invoke(nameof(EndFever), feverTime);
				
				if (hasResetCrystalsAfterFever) {
					ResourceHolder.ResetCrystals();
				}

				SaveAmountOfCrystals();
			}
		}

		private void SaveAmountOfCrystals() {
			_amountOfCrystalsAtLastFever = ResourceHolder.Crystals;
		}

		private void StartFever() {
			_hasFever = true;

			_movementController.HasLockInput = true;
			_movementController.ForwardSpeed *= speedMultiplier;

			if (_playerDeath) {
				_playerDeath.HasInvulnerability = true;
			}

			transform.DOMoveX(feverXAxisPosition, durationToSetFeverPosition);
		}

		private void EndFever() {
			_hasFever = false;
			
			_movementController.HasLockInput = false;
			_movementController.ForwardSpeed /= speedMultiplier;
			
			if (_playerDeath) {
				_playerDeath.HasInvulnerability = false;
			}
		}
	}
}
using Core.MaterialChanger;
using UnityEngine;

namespace Core.Player.DeathCheckers {
	public class ColorChecker : Checker {
		private MaterialController _materialController;

		private void Awake() {
			_materialController = GetComponentInParent<MaterialController>();
		}

		private void OnTriggerEnter(Collider other) {
			if (other.TryGetComponent(out MaterialController otherMaterialController)) {
				bool hasSpray = other.TryGetComponent(out SprayPlayer sprayPlayer);
				if (!hasSpray && _materialController.ColorType != otherMaterialController.ColorType) {
					IsDying?.Invoke();
				}
			}
		}
	}
}
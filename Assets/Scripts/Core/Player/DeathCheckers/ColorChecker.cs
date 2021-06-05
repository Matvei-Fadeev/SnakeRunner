using System;
using Core.MaterialChanger;
using Core.MaterialChanger.MaterialChangers;
using UnityEngine;

namespace Core.Player.DeathCheckers {
	public class ColorChecker : Checker {
		[SerializeField] private AbstractMaterialChanger _materialChanger;

		private void Awake() {
			if (!_materialChanger) {
				throw new UnityException($"Set the {_materialChanger} to the {gameObject.name}");
			}
		}

		private void OnTriggerEnter(Collider other) {
			var otherMaterialController = other.GetComponentInChildren<AbstractMaterialChanger>();
			if (otherMaterialController) {
				bool hasSpray = other.TryGetComponent(out SprayPlayer sprayPlayer);
				if (!hasSpray && _materialChanger.GetMaterial.name != otherMaterialController.GetMaterial.name) {
					IsDying?.Invoke();
				}
			}
		}
	}
}
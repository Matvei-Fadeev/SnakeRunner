using Core.DataComponents;
using Data.Resource;
using UnityEngine;

namespace Core.Player.DeathCheckers {
	public class BarrierChecker : Checker {
		private void OnTriggerEnter(Collider other) {
			if (other.TryGetComponent(out ResourceComponent resource)) {
				if (resource.Type == ResourceType.Barrier) {
					IsDying?.Invoke();
				}
			}
		}
	}
}
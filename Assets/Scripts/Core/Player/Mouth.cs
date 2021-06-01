using System;
using Core.Holder;
using Data;
using UnityEngine;

namespace Core.Player {
	public class Mouth : MonoBehaviour {
		private void OnTriggerEnter(Collider enemy) {
			if (enemy.TryGetComponent(out Resource resource)) {
				AddResourceCount(resource);
				resource.DestroyResource();
			}
		}

		private static void AddResourceCount(Resource resource) {
			var count = resource.Count;
			switch (resource.Type) {
				case ResourceType.None:
					throw new UnityException("Set the ResourceType to the " + resource.gameObject.name);
				case ResourceType.Crystal:
					ResourceHolder.Crystals += count;
					break;
				case ResourceType.Score:
					ResourceHolder.Score += count;
					break;
				default:
					throw new ArgumentOutOfRangeException();
			}
		}
	}
}
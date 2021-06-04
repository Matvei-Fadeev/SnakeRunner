using System;
using Core.DataComponents;
using Data.Resource;
using UnityEngine;

namespace Core.Player {
	public class Mouth : MonoBehaviour {
		private SnakeBody _snakeBody;

		private void Awake() {
			if (!TryGetComponent(out _snakeBody)) {
				_snakeBody = GetComponentInParent<SnakeBody>();
			}
		}

		private void OnTriggerEnter(Collider enemy) {
			if (enemy.TryGetComponent(out ResourceComponent resource)) {
				AddResourceCountToHandler(resource);
				AddResourceCountToSnakeBody(resource);
			}
		}

		private static void AddResourceCountToHandler(ResourceComponent resourceComponent) {
			var count = resourceComponent.Count;
			switch (resourceComponent.Type) {
				case ResourceType.None:
					throw new UnityException("Set the ResourceType to the " + resourceComponent.gameObject.name);
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

		private void AddResourceCountToSnakeBody(ResourceComponent resourceComponent) {
			_snakeBody.AddBody(resourceComponent.Count);
		}
	}
}
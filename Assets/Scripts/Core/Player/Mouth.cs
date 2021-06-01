using System;
using Core.Holder;
using Data;
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
			if (enemy.TryGetComponent(out Resource resource)) {
				AddResourceCountToHandler(resource);
				AddResourceCountToSnakeBody(resource);
			}
		}

		private static void AddResourceCountToHandler(Resource resource) {
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

		private void AddResourceCountToSnakeBody(Resource resource) {
			_snakeBody.AddBody(resource.Count);
		}
	}
}
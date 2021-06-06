using System;
using Core.DataComponents;
using Data.Resource;
using UnityEngine;

namespace Core.Player {
	public class Mouth : MonoBehaviour {
		public static Action ScoreHasEaten;
		
		[Header("Increase configuration")]
		[SerializeField] private bool hasIncreaseByCrystals;

		[SerializeField] private bool hasIncreaseByFood = true;

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
				case ResourceType.Barrier:
					break;
				default:
					throw new ArgumentOutOfRangeException();
			}
		}

		private void AddResourceCountToSnakeBody(ResourceComponent resourceComponent) {
			var resourceComponentCount = 0;
			switch (resourceComponent.Type) {
				case ResourceType.None:
					throw new UnityException("Set the ResourceType to the " + resourceComponent.gameObject.name);
				case ResourceType.Crystal:
					resourceComponentCount = hasIncreaseByCrystals ? resourceComponent.Count : resourceComponentCount;
					break;
				case ResourceType.Score:
					ScoreHasEaten?.Invoke();
					resourceComponentCount = hasIncreaseByFood ? resourceComponent.Count : resourceComponentCount;
					break;
				case ResourceType.Barrier:
					break;
				default:
					throw new ArgumentOutOfRangeException();
			}

			_snakeBody.AddBody(resourceComponentCount);
		}
	}
}
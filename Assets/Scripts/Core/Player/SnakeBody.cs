using System.Collections.Generic;
using UnityEngine;

namespace Core.Player {
	public class SnakeBody : MonoBehaviour {
		[Header("Objects to spawn")]
		[SerializeField] private GameObject bodyPart;

		[SerializeField] private GameObject tailPrefab;

		[Header("Configuration")]
		[SerializeField] private float partDistance = 0f;
		[SerializeField] private int defaultAmountOfParts = 0;

		[Header("Snake body parts")]
		[SerializeField] private List<GameObject> _parts;
		
		private Vector3 _invisibleSpawnPosition = new Vector3(-999, -999);
		private GameObject _tailGameObject;

		public List<GameObject> Parts => _parts;

		private void Awake() {
			_parts = new List<GameObject>();
			if (!tailPrefab) {
				throw new UnityException("Set the tailPrefab to the SnakeBody scripts");
			}

			_tailGameObject = Instantiate(tailPrefab, _invisibleSpawnPosition, default);

			AddBody(defaultAmountOfParts);
		}

		private void Update() {
			MoveBodyAndTail();
		}

		/// <param name="count">The number of body parts to appear</param>
		public void AddBody(int count = 1) {
			var objectToClone = _parts.Count > 0 ? _parts[0] : bodyPart;
			for (int i = 0; i < count; i++) {
				var newPart = Instantiate(objectToClone, _invisibleSpawnPosition, default);
				_parts.Add(newPart);
			}
		}

		/// <param name="count">The number of body parts to be removed from the snake's tail</param>
		public void RemoveFromTail(int count = 1) {
			if (_parts.Count == 0) {
				return;
			}

			var countToDelete = GetCountToDelete(count);
			var index = GetIndexOfStartedDeleting(count);

			RemoveByIndexAndCount(index, countToDelete);
		}

		private int GetIndexOfStartedDeleting(int count) {
			int index = 0;
			if (count < _parts.Count) {
				index = _parts.Count - 1 - count;
			}

			return index;
		}

		private int GetCountToDelete(int count) {
			int countToDelete = Mathf.Min(_parts.Count, count);
			return countToDelete;
		}

		private void RemoveByIndexAndCount(int index, int countToDelete) {
			for (int i = index; i < index + countToDelete; i++) {
				var body = _parts[i];
				Destroy(body);
			}

			_parts.RemoveRange(index, countToDelete);
		}

		private void MoveBodyAndTail() {
			Vector3 previousPosition = transform.position - transform.forward * partDistance;
			Quaternion previousRotation = transform.rotation;

			var hasMoveBody = MoveBody(ref previousPosition, ref previousRotation);

			if (hasMoveBody) {
				// Move tail
				_tailGameObject.transform.SetPositionAndRotation(previousPosition, previousRotation);
			}
		}

		private bool MoveBody(ref Vector3 previousPosition, ref Quaternion previousRotation) {
			foreach (var part in _parts) {
				var body = part.transform;
				if ((body.position - previousPosition).sqrMagnitude > partDistance * partDistance) {
					var position = SwapPosition(body.position, ref previousPosition);
					var rotation = SwapRotation(body.rotation, ref previousRotation);
					body.SetPositionAndRotation(position, rotation);
				}
				else {
					return false;
				}
			}

			return true;
		}

		private static Vector3 SwapPosition(Vector3 bodyPosition, ref Vector3 previousPosition) {
			Vector3 position = previousPosition;
			previousPosition = bodyPosition;
			return position;
		}

		private static Quaternion SwapRotation(Quaternion bodyRotation, ref Quaternion previousRotation) {
			Quaternion rotation = previousRotation;
			previousRotation = bodyRotation;
			return rotation;
		}
	}
}
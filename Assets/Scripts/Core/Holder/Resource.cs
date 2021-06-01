using UnityEngine;

namespace Core.Holder {
	public class Resource : MonoBehaviour {
		[SerializeField] private ResourceType resourceType;
		[SerializeField] private int count;

		public ResourceType Type => resourceType;
		public int Count => count;

		public void DestroyResource() {
			Destroy(gameObject);
		}
	}
}
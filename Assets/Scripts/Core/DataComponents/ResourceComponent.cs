using Data.Resource;
using UnityEngine;

namespace Core.DataComponents {
	public class ResourceComponent : MonoBehaviour {
		[SerializeField] private ResourceType resourceType;
		[SerializeField] private int count;

		public ResourceType Type => resourceType;
		public int Count => count;
	}
}
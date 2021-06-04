using UnityEngine;

namespace Core.MaterialChanger.MaterialChangers {
	public class MaterialChangerOfMeshRenderer : MonoBehaviour, IMaterialChanger {
		public void SetMaterial(Material material) {
			if (TryGetComponent(out MeshRenderer meshRenderer)) {
				meshRenderer.material = material;
			}
			else {
				throw new UnityException($"Set the MeshRenderer to the {gameObject.name}");
			}
		}
	}
}
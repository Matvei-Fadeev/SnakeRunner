using UnityEngine;

namespace Core.MaterialChanger.MaterialChangers {
	public class MaterialChangerOfMeshRenderer : AbstractMaterialChanger {
		protected override void ChangeMaterial(Material material) {
			if (TryGetComponent(out MeshRenderer meshRenderer)) {
				meshRenderer.material = material;
			}
			else {
				throw new UnityException($"Set the MeshRenderer to the {gameObject.name}");
			}
		}
	}
}
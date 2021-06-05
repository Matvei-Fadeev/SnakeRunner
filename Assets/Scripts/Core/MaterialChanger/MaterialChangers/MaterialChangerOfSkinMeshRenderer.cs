using UnityEngine;

namespace Core.MaterialChanger.MaterialChangers {
	public class MaterialChangerOfSkinMeshRenderer : AbstractMaterialChanger {
		protected override void ChangeMaterial(Material material) {
			if (TryGetComponent(out SkinnedMeshRenderer meshRenderer)) {
				meshRenderer.material = material;
			}
			else {
				throw new UnityException($"Set the MeshRenderer to the {gameObject.name}");
			}
		}
	}
}
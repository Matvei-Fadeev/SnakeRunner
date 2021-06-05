using UnityEngine;

namespace Core.MaterialChanger.MaterialChangers {
	public class ColorChangerOfParticleSystem : AbstractMaterialChanger {
		protected override void ChangeMaterial(Material material) {
			if (TryGetComponent(out ParticleSystem particleSystem)) {
				ParticleSystem.MainModule particleSystemMain = particleSystem.main;
				particleSystemMain.startColor = material.color;
			}
			else {
				throw new UnityException($"Set the MeshRenderer to the {gameObject.name}");
			}
		}
	}
}
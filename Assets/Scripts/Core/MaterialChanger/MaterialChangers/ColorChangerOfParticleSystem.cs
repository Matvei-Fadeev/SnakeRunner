using UnityEngine;

namespace Core.MaterialChanger.MaterialChangers {
	public class ColorChangerOfParticleSystem : MonoBehaviour, IMaterialChanger {
		public void SetMaterial(Material material) {
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
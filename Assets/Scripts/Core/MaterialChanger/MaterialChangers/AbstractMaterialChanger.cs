using UnityEngine;

namespace Core.MaterialChanger.MaterialChangers {
	public abstract class AbstractMaterialChanger : MonoBehaviour {
		private Material _material;

		public Material GetMaterial => _material;

		public void SetMaterial(Material material) {
			_material = material;
			ChangeMaterial(material);
		}

		protected abstract void ChangeMaterial(Material material);
	}
}
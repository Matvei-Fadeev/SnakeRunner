using System.Collections.Generic;
using Core.MaterialChanger.MaterialChangers;
using Data.Color;
using DG.Tweening;
using UnityEngine;

namespace Core.MaterialChanger {
	[ExecuteInEditMode]
	public class MaterialController : MonoBehaviour {
		[Header("Configuration")]
		[SerializeField] private ColorType colorType = ColorType.Default;
		[SerializeField] private float durationToChangeColor = 1f;
		[SerializeField] private bool changeChildrenMaterial = true;

		private const string ColorHolderResourcesPath = "ColorHolder";
		private ColorHolder _colorHolder;
		private List<AbstractMaterialChanger> _materialChangers;

		public ColorType ColorType => colorType;

		private void Awake() {
			SetMaterialChangers();
			_colorHolder = Resources.Load<ColorHolder>(ColorHolderResourcesPath);
			Material material = new Material(_colorHolder.GetMaterialByType(colorType));
			SetMaterialToMaterialChangers(material);
		}

		public void SetMaterial(ColorType newColorType) {
			colorType = newColorType;
			SetMaterialToMaterialChangers(_colorHolder.GetMaterialByType(colorType));
		}

		private void SetMaterialChangers() {
			_materialChangers = new List<AbstractMaterialChanger>(GetComponents<MaterialChangerOfMeshRenderer>());
			if (changeChildrenMaterial) {
				var componentsInChildren = GetComponentsInChildren<AbstractMaterialChanger>();
				_materialChangers.AddRange(componentsInChildren);
			}
		}

		private void SetMaterialToMaterialChangers(Material meshRendererMaterial) {
			if (_materialChangers.Count == 0) {
				Debug.LogWarning($"{gameObject.name} doesn't have material");
			}

			foreach (var materialChanger in _materialChangers) {
				materialChanger.SetMaterial(meshRendererMaterial);
			}
		}
	}
}
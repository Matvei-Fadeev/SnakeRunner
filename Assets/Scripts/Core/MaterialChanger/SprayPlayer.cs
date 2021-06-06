using System.Linq;
using Data.Color;
using UnityEngine;

namespace Core.MaterialChanger {
	public class SprayPlayer : MonoBehaviour {
		[SerializeField] private string[] tags = new[] {"Player", "SnakePart"};

		private ColorType _colorType;

		private void Awake() {
			if (TryGetComponent(out MaterialController materialController)) {
				_colorType = materialController.ColorType;
			}
			else {
				throw new UnityException($"Set {nameof(MaterialController)} to the {gameObject.name}");
			}
		}

		private void OnTriggerEnter(Collider other) {
			if (tags.Any(other.CompareTag)) {
				SetColor(other.gameObject);
			}
		}

		private void SetColor(GameObject player) {
			if (player.TryGetComponent(out MaterialController playerMaterialController)) {
				playerMaterialController.SetMaterial(_colorType);
			}
		}
	}
}
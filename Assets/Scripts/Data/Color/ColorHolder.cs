using System;
using UnityEngine;

namespace Data.Color {
	public class ColorHolder : MonoBehaviour {
		[SerializeField] private GameColor[] gameColors;

		public UnityEngine.Color GetColorByType(ColorType colorType) {
			return GetMaterialByType(colorType).color;
		}

		public Material GetMaterialByType(ColorType colorType) {
			foreach (var gameColor in gameColors) {
				if (gameColor.colorType == colorType) {
					return gameColor.material;
				}
			}

			throw new Exception("Set the " + colorType);
		}
	}
}
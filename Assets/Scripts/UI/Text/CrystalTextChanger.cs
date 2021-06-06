using System;
using Data.Resource;

namespace UI.Text {
	/// <summary>
	/// Set on the CrystalText GameObject
	/// </summary>
	public class CrystalTextChanger : TextChanger {
		private void OnEnable() {
			
			ResourceHolder.CrystalsChanged += ReceiveValue;
		}

		private void Start() {
			ReceiveValue(null, ResourceHolder.Crystals);
		}

		private void OnDisable() {
			ResourceHolder.CrystalsChanged -= ReceiveValue;
		}
	}
}
using Data;
using Data.Resource;

namespace UI.Text {
	/// <summary>
	/// Set on the CrystalText GameObject
	/// </summary>
	public class CrystalTextChanger : TextChanger {
		private void OnEnable() {
			ResourceHolder.CrystalsChanged += ReceiveValue;
		}

		private void OnDisable() {
			ResourceHolder.CrystalsChanged -= ReceiveValue;
		}
	}
}
using Data;
using Data.Resource;

namespace UI.Text {
	/// <summary>
	/// Set on the ScoreText GameObject
	/// </summary>
	public class ScoreTextChanger : TextChanger {
		private void OnEnable() {
			ResourceHolder.ScoreChanged += ReceiveValue;
		}

		private void Start() {
			ReceiveValue(null, ResourceHolder.Score);
		}
		
		private void OnDisable() {
			ResourceHolder.ScoreChanged -= ReceiveValue;
		}
	}
}
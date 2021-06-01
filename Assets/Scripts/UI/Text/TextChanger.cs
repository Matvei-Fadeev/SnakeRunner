using UnityEngine;

namespace UI.Text {
	/// <summary>
	/// Set on the Text GameObject
	/// </summary>
	public class TextChanger : MonoBehaviour {
		private UnityEngine.UI.Text _text;
		private int _count;

		private int Count {
			get => _count;
			set {
				_count = value;
				UpdateText();
			}
		}

		private void Awake() {
			_text = GetComponent<UnityEngine.UI.Text>();
		}
		
		protected void ReceiveValue(object sender, int newCount) {
			Count = newCount;
		}

		private void UpdateText() {
			_text.text = _count.ToString();
		}
	}
}
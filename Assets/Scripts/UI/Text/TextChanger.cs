using TMPro;
using UnityEngine;

namespace UI.Text {
	/// <summary>
	/// Set on the Text GameObject
	/// </summary>
	public class TextChanger : MonoBehaviour {
		[Header("Configuration")]
		[SerializeField] private float delayBetweenTextUpdates = 0.1f;
		[SerializeField] private int maxCountPerUpdate = 1;

		private TextMeshProUGUI _text;
		private int _count;
		private int _displayedCount;
		private bool _alreadyIncrease;

		private int Count {
			get => _count;
			set {
				_count = value;
				if (!_alreadyIncrease) {
					_alreadyIncrease = true;
					InvokeRepeating(nameof(AnimatedIncreaseDisplayedCount), 0f, delayBetweenTextUpdates);
				}			
			}
		}

		private void Awake() {
			_text = GetComponent<TextMeshProUGUI>();
		}

		private void AnimatedIncreaseDisplayedCount() {
			_displayedCount += maxCountPerUpdate;
			if (_displayedCount > _count) {
				_displayedCount = _count;
				_alreadyIncrease = false;
			}

			UpdateText(_displayedCount);
		}

		protected void ReceiveValue(object sender, int newCount) {
			Count = newCount;
		}

		private void UpdateText(int count) {
			_text.text = count.ToString();
		}
	}
}
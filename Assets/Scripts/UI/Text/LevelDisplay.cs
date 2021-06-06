using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace UI.Text {
	public class LevelDisplay : MonoBehaviour {
		[Header("Configuration")]
		[SerializeField] private bool hasOnlyUpper = true;
		[SerializeField] private bool replaceSymbolsOnSpace = true;

		private TextMeshProUGUI _levelText;
		
		private void Awake() {
			_levelText = GetComponent<TextMeshProUGUI>();
		}

		private void Start() {
			SetLevelText();
		}

		private void SetLevelText() {
			string text = SceneManager.GetActiveScene().name;
			if (replaceSymbolsOnSpace) {
				text = text.Replace("-", " ").Replace("_", " ");
			}

			if (hasOnlyUpper) {
				text = text.ToUpper();
			}
			_levelText.text = text;
		}
	}
}
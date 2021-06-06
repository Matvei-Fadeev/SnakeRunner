using System;

namespace Data.Resource {
	/// <summary>
	/// Containe the score and crystal values
	/// </summary>
	public static class ResourceHolder {
		public static event EventHandler<int> ScoreChanged;
		public static event EventHandler<int> CrystalsChanged;

		private static int _score = 0;
		private static int _crystals = 0;

		public static int Score {
			get => _score;
			set {
				_score = value;
				ScoreChanged?.Invoke(null, _score);
			}
		}

		public static int Crystals {
			get => _crystals;
			set {
				_crystals = value;
				CrystalsChanged?.Invoke(null, _crystals);
			}
		}

		/// <summary>
		/// Set to default value the Score and Crystals
		/// </summary>
		public static void Reset() {
			ResetScore();
			ResetCrystals();
		}

		public static void ResetCrystals() {
			Crystals = 0;
		}
		
		public static void ResetScore() {
			Score = 0;
		}
	}
}
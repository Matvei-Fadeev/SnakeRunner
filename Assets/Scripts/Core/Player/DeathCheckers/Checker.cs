using System;
using UnityEngine;

namespace Core.Player.DeathCheckers {
	public abstract class Checker : MonoBehaviour {
		public Action IsDying;
	}
}
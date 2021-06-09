using UnityEngine;

namespace Input.Touches.Target {
	public abstract class TargetInputHandler : InputHandler {
		[Header("Target to calculate direction")]
		[SerializeField] private string targetTag = "Player";

		[Tooltip("Direction is normilized and independent from distance between target and touch position")]
		[SerializeField] protected bool useNormalizedDirection = true;

		protected Transform Target;
		protected UnityEngine.Camera Camera;

		protected new void Awake() {
			base.Awake();
			
			Target = GameObject.FindGameObjectWithTag(targetTag).transform;
			Camera = UnityEngine.Camera.main;
		}

		public override float GetVertical() {
			return GetDirection().y;
		}

		public override float GetHorizontal() {
			return GetDirection().x;
		}
	}
}
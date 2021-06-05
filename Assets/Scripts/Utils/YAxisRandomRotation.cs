using DG.Tweening;
using UnityEngine;

namespace Utils {
	public class YAxisRandomRotation : MonoBehaviour {
		[SerializeField] private float rotationDuration = 1f;
		
		private void Start() {
			var rotation = transform.rotation;
			rotation.y = Random.rotation.y;
			transform.DORotate(rotation.eulerAngles, rotationDuration);
		}
	}
}
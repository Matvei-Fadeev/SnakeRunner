﻿using System;
using UnityEngine;

namespace Camera {
	public class CameraFollow : MonoBehaviour {
		[Tooltip("If we need sometimes to turn off camera movement")]
		[HideInInspector]
		public bool hasFreezeMovement;
		
		[Header("Object to follow")]
		[SerializeField] private string tagOfTarget = "Player";

		[Header("Configuration")]
		[Tooltip("The axis which will be freezed")]
		[SerializeField] private Axis freezeAxis;

		private Transform _target;
		private Vector3 _defaultPosition;
		private Vector3 _offsetFromTarget;

		private void Awake() {
			if (!_target) {
				_target = GameObject.FindGameObjectWithTag(tagOfTarget).transform;
			}

			// Set to offset the start default camera position
			_defaultPosition = gameObject.transform.position;
			_offsetFromTarget = gameObject.transform.position;
		}

		private void Update() {
			if (!hasFreezeMovement) {
				SetCameraAbove();
			}
		}

		private void SetCameraAbove() {
			if (_target) {
				var newPosition = _target.position + _offsetFromTarget;
				FreezeCameraMovementAxis(ref newPosition);
				transform.position = newPosition;
			}
		}

		private void FreezeCameraMovementAxis(ref Vector3 position) {
			if (freezeAxis.x) {
				position.x = _defaultPosition.x;
			}

			if (freezeAxis.y) {
				position.y = _defaultPosition.y;
			}

			if (freezeAxis.z) {
				position.z = _defaultPosition.z;
			}
		}

		[Serializable]
		private struct Axis {
			public bool x;
			public bool y;
			public bool z;
		}
	}
}
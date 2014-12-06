using UnityEngine;
using System.Collections;

public class MoveObjectUp : MonoBehaviour {

	private float _orbitalHeight;
	private Vector3 _planetPosition;
	
	private void Update() {
		rigidbody.velocity = transform.up;
		float distance = Vector3.Distance(transform.position, _planetPosition);
		if (distance > _orbitalHeight) {
			rigidbody.velocity = Vector3.zero;
			Destroy(this);
		}
	}

	public float orbitalHeight {
		set {
			_orbitalHeight = value;
		}
	}

	public Vector3 planetPosition {
		set {
			_planetPosition = value;		
		}
	}

}

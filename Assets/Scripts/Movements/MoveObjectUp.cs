using UnityEngine;
using System.Collections;

public class MoveObjectUp : MonoBehaviour {

	private float _orbitalHeight;
	
	private void Update() {
		rigidbody.velocity = transform.up;
		// if (false) {
		// 	Destroy(this);
		// }
	}

	public float orbitalHeight {
		set {
			_orbitalHeight = value;
		}
	}

}

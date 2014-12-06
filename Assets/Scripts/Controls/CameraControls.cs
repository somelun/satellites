using UnityEngine;
using System.Collections;

public class CameraControls : MonoBehaviour {

	public Transform target;

	private float RotationSpeed = 45.0f;
	
	private void Update() {
		Vector3 rotation;

		int vertical = (int)Input.GetAxis("Vertical");
		int horizontal = (int)Input.GetAxis("Horizontal");

		if (vertical != 0 || horizontal != 0) {
			rotation = new Vector3(vertical, horizontal, 0);
			transform.RotateAround(target.position, rotation, RotationSpeed * Time.deltaTime);
		}

	}
}

using UnityEngine;
using System.Collections;

public class CameraMovement : MonoBehaviour {

	// public 

	private void Start() {
		//
	}
	
	private void Update() {
		transform.RotateAround(Vector3.zero, Vector3.up, 20 * Time.deltaTime);
	}

}

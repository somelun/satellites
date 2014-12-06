using UnityEngine;
using System.Collections;

public class MoveObject : MonoBehaviour {

	public float speed;
	public Transform target;
	
	private void Update() {
		transform.RotateAround(target.position, Vector3.up, speed * Time.deltaTime);
	}

}

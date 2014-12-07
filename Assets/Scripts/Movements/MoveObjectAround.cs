using UnityEngine;
using System.Collections;

public class MoveObjectAround : MonoBehaviour {

	public float speed;
	public Transform target;
	
	private void Update() {
		transform.RotateAround(target.position, transform.right, speed * Time.deltaTime);
	}

}

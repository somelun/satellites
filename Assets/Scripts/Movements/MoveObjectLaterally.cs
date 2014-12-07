using UnityEngine;
using System.Collections;

public class MoveObjectLaterally : MonoBehaviour {
	
	public void RotateObject(Vector3 vector) {
		transform.Rotate(0, 15, 0, Space.Self);
	}
}

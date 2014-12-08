using UnityEngine;
using System.Collections;

public class MoveObjectLaterally : MonoBehaviour {
	
	public void RotateObject(int dir) {
		if (dir == 0) {
			transform.Rotate(0, -5, 0, Space.Self);
		} else {
			transform.Rotate(0, 5, 0, Space.Self);
		}
	}
}

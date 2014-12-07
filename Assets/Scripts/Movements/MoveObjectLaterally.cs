using UnityEngine;
using System.Collections;

public class MoveObjectLaterally : MonoBehaviour {
	
	public void RotateObject(int dir) {
		if (dir == 0) {
			transform.Rotate(0, -15, 0, Space.Self);
		} else {
			transform.Rotate(0, 15, 0, Space.Self);
		}
	}
}

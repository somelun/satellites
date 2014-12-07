﻿using UnityEngine;
using System.Collections;

public class GameControls : MonoBehaviour {

	public Transform target;

	private float RotationSpeed = 45.0f;
	
	private void Update() {
		Vector3 rotation;

		int vertical = (int)Input.GetAxis("Vertical");
		int horizontal = (int)Input.GetAxis("Horizontal");

		if (vertical != 0 || horizontal != 0) {
			rotation = new Vector3(vertical, horizontal, 0);
			Camera.main.gameObject.transform.RotateAround(target.position, rotation, RotationSpeed * Time.deltaTime);
		}

		if(Input.GetButtonDown("Jump")) {
			SatellitesManager.Instance.SelectNextSatellite();
		}

		Vector3 force = Vector3.zero;
		if(Input.GetKeyDown("w")) {
			force = new Vector3(25, 0, 0);
		} else if(Input.GetKeyDown("s")) {
			// force = new Vector3(25, 0, 0);;
		} else if(Input.GetKeyDown("a")) {
			// force = new Vector3(25, 0, 0);
		} else if(Input.GetKeyDown("d")) {
			// force = new Vector3(25, 0, 0);
		} else {
			// force = Vector3.zero;
		}

		 if (force != Vector3.zero) {
			SatellitesManager.Instance.SelectedSatellite().GetComponent<MoveObjectLaterally>().RotateObject(force);
		 }
		

	}
	
}

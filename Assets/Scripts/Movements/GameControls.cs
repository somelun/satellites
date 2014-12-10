using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameControls : MonoBehaviour {

	public Transform target;

	public GameObject restart;
	public GameObject message;

	private float RotationSpeed = 90.0f;
	
	private void Update() {
		Vector3 rotation;

		int vertical = (int)Input.GetAxis("Vertical");
		int horizontal = (int)Input.GetAxis("Horizontal");

		if (vertical != 0 || horizontal != 0) {
			// vertiacalVector		= new Vector3(vectical, 0.0f, 0.0f);
			// horizontalVector	= new Vector3(0.0f, horizontal, 0.0f);
			rotation = new Vector3(vertical, horizontal, 0);
			Transform cameraTransform = Camera.main.transform;
			cameraTransform.RotateAround(target.position, cameraTransform.TransformDirection(rotation), RotationSpeed * Time.deltaTime);
		}

		if (SatellitesManager.Instance.SatellitesCount() > 0) {
			if(Input.GetButtonDown("Jump")) {
				SatellitesManager.Instance.SelectNextSatellite();
			}

			if(Input.GetKey("a")) {
				SatellitesManager.Instance.SelectedSatellite().GetComponent<MoveObjectLaterally>().RotateObject(0);	//left
				SatellitesManager.Instance.SelectedSatellite().GetComponent<MoveObjectAround>().UpdateTrajectory();
				SatellitesManager.Instance.SelectedSatellite().GetComponent<MoveObjectAround>().DrawTrajectory();
			} else if(Input.GetKey("d")) {
				SatellitesManager.Instance.SelectedSatellite().GetComponent<MoveObjectLaterally>().RotateObject(1); //right
				SatellitesManager.Instance.SelectedSatellite().GetComponent<MoveObjectAround>().UpdateTrajectory();
				SatellitesManager.Instance.SelectedSatellite().GetComponent<MoveObjectAround>().DrawTrajectory();
			}
		}

		if (SatellitesManager.Instance.DestroyedSatellitesCount() >= 1) {
			SatellitesManager.Instance.PurgeData();
			this.enabled = false;
			restart.SetActive(true);
			restart.GetComponent<Button>().interactable = true;
			message.SetActive(true);
		}

	}
	
}

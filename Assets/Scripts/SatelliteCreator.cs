using UnityEngine;
using System.Collections;

public class SatelliteCreator : MonoBehaviour {

	public GameObject satellite;

	private void Start () {
		Vector3 startPosition = new Vector3(0, 0, -19);
		CreateSatellite(startPosition);
	}

	private void CreateSatellite(Vector3 position) {
		GameObject.Instantiate(satellite, position, Quaternion.identity);
	}

}

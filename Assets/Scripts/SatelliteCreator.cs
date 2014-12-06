using UnityEngine;
using System.Collections;

public class SatelliteCreator : MonoBehaviour {

	public GameObject satellite;

	private void Start () {
		Vector3 startPosition = new Vector3(Random.Range(20.0f, 25.0f), 0, 0);
		CreateSatellite(startPosition);
	}

	private void CreateSatellite(Vector3 position) {
		Instantiate(satellite, position, Quaternion.identity);
	}

}

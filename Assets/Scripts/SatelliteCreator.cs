using UnityEngine;
using System.Collections;

public class SatelliteCreator : MonoBehaviour {

	public GameObject planet;
	public GameObject satellite;
	public float creationPeriod = 3.0f;

	private void Start() {
		StartCoroutine("CrateCoroutine");
	}

	private void CreateSatellite() {
		Vector3 localPlanetLaunchPosition = Random.onUnitSphere * 0.5f;
		Vector3 startPosition = planet.transform.TransformPoint(localPlanetLaunchPosition);

		Vector3 relativePos = planet.transform.position - startPosition;
        Quaternion rotation = Quaternion.LookRotation(relativePos);

		GameObject satelliteObject = GameObject.Instantiate(satellite, startPosition, rotation) as GameObject;
	}

	IEnumerator CrateCoroutine() {
		while(true) {
			CreateSatellite();
			yield return new WaitForSeconds(creationPeriod);
		}
	}

}

	// 	float planetR = planet.transform.localScale.x / 2;
	// 	float orbitalHeight = Random.Range(planetR * 2, planetR * 4);
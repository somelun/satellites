using UnityEngine;
using System.Collections;

public class SatelliteCreator : MonoBehaviour {

	public GameObject planet;
	public GameObject satellite;
	public float creationPeriod = 3.0f;

	private int count = 18;

	private void Start() {
		StartCoroutine("CrateCoroutine");
	}

	private void CreateSatellite() {
		Vector3 localPlanetLaunchPosition = Random.onUnitSphere * 0.5f;
		Vector3 startPosition = planet.transform.TransformPoint(localPlanetLaunchPosition);

		Vector3 relativePosition = (startPosition - planet.transform.position).normalized;
        Quaternion rotation = Quaternion.LookRotation(Vector3.forward, relativePosition);

        Debug.DrawLine(startPosition, planet.transform.position * 100.0f, Color.green, 30.0f);

        float planetR = planet.transform.localScale.x / 2;

		GameObject satelliteObject = GameObject.Instantiate(satellite, startPosition, rotation) as GameObject;

		satelliteObject.GetComponent<MoveObjectUp>().orbitalHeight = planetR * 1.5f;
		satelliteObject.GetComponent<MoveObjectUp>().planetPosition = planet.transform.position;

		count = count - 1;
	}

	IEnumerator CrateCoroutine() {
		while(count > 0) {
			CreateSatellite();
			yield return new WaitForSeconds(creationPeriod);
		}
	}

}

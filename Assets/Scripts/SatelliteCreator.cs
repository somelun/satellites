using UnityEngine;
using System.Collections;

public class SatelliteCreator : MonoBehaviour {

	public GameObject planet;
	public GameObject satellite;
	public float creationPeriod = 1.5f;

	private int count = 18;
	private bool isGenerationStarted;

	private void Update() {
		if (GameObject.Find("Button"))
			return;

		if (isGenerationStarted)
			return;

		StartCoroutine("CreateCoroutine");
		isGenerationStarted = true;
	}

	private void CreateSatellite() {
		Vector3 localPlanetLaunchPosition = Random.onUnitSphere * 0.5f;
		Vector3 startPosition = planet.transform.TransformPoint(localPlanetLaunchPosition);

		Vector3 up = (startPosition - planet.transform.position).normalized;
		Vector3 orthoLeft = Vector3.Cross(Vector3.forward, up);
		Vector3 orthoForward = Vector3.Cross(orthoLeft, up);
        Quaternion rotation = Quaternion.LookRotation(orthoForward, up);

        float planetR = planet.transform.localScale.x / 2;

		GameObject satelliteObject = GameObject.Instantiate(satellite, startPosition, rotation) as GameObject;

		satelliteObject.GetComponent<MoveObjectUp>().orbitalHeight = planetR * 1.5f;
		satelliteObject.GetComponent<MoveObjectUp>().planetPosition = planet.transform.position;

		SatellitesManager.Instance.AddSatellite(satelliteObject);

		count = count - 1;
		creationPeriod = creationPeriod * 1.5f;
	}

	private IEnumerator CreateCoroutine() {
		while(count > 0) {
			CreateSatellite();
			yield return new WaitForSeconds(creationPeriod);
		}
	}

}

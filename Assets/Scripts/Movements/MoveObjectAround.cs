using UnityEngine;
using System.Collections;

[RequireComponent(typeof(AudioSource))]
public class MoveObjectAround : MonoBehaviour {

	public float speed;
	public Transform target;
	public bool needDrawTrajectory;
	public AudioClip audioClip;
	
	private Color color;
    private LineRenderer lineRenderer;
    private int numLineSegments = 18;

    private Vector3 trajectoryUp;

    private void Start() {
    	color = new Color(Random.Range(0.0f, 1.0f), Random.Range(0.0f, 1.0f), Random.Range(0.0f, 1.0f), 0.3f);

    	speed = Random.Range(6, 12);

    	return;

		lineRenderer = gameObject.AddComponent<LineRenderer>();

		lineRenderer.material = Constants.lineMaterial;
		lineRenderer.startColor = color;
		lineRenderer.endColor = color;
		lineRenderer.startWidth = 0.2f;
		lineRenderer.endWidth = 0.2f;
		lineRenderer.numPositions = numLineSegments + 1;

		UpdateTrajectory();
    }
	
	private void Update() {
		transform.RotateAround(target.position, transform.right, speed * Time.deltaTime);

		if (GetComponent<MoveObjectUp>()) {
			DrawTrajectory();
		}
	}

	public void DrawTrajectory() {
		return;

		if (!needDrawTrajectory) {
			return;
		}

		float distanceToCenter = Vector3.Distance(transform.position, target.position);
		
		float step = 360.0f / numLineSegments;

		for (int i = 0; i < numLineSegments + 1; ++i) {
			Vector3 rotatedUp = Quaternion.AngleAxis(step * i, transform.right) * trajectoryUp;
			Vector3 nextPos = target.position + rotatedUp * distanceToCenter;
			lineRenderer.SetPosition(i, nextPos);
		}
	}

	public void UpdateTrajectory() {
		trajectoryUp = transform.up;
	}

	private void OnTriggerEnter(Collider other) {
		// if (!GameObject.Find("GameControls").activeSelf)
		// 	return;

		ParticlesCreator.CreateDebrisParticles(gameObject.transform.position);
		
		SatellitesManager.Instance.SelectNextSatelliteAfterCrash();
		SatellitesManager.Instance.RemoveSatellite(gameObject);
		Destroy(gameObject);
	}

}

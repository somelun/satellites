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

    private void Start() {
    	color = new Color(Random.Range(0.0f, 1.0f), Random.Range(0.0f, 1.0f), Random.Range(0.0f, 1.0f));

		lineRenderer = gameObject.AddComponent<LineRenderer>();

		lineRenderer.material = new Material(Shader.Find("Particles/Additive"));
		lineRenderer.SetColors(color, color);
		lineRenderer.SetWidth(0.2f, 0.2f);
		lineRenderer.SetVertexCount(numLineSegments + 1);

		DrawTrajectory();
    }
	
	private void Update() {
		transform.RotateAround(target.position, transform.right, speed * Time.deltaTime);

		if (GetComponent<MoveObjectUp>()) {
			DrawTrajectory();
		}
	}

	public void DrawTrajectory() {
		if (!needDrawTrajectory) return;

		float distanceToCenter = Vector3.Distance(transform.position, target.position);
		
		float step = 360.0f / numLineSegments;
		for (int i = 0; i < numLineSegments + 1; ++i) {
			Vector3 rotatedUp = Quaternion.AngleAxis(step * i, transform.right) * transform.up;
			Vector3 nextPos = target.position + rotatedUp * distanceToCenter;
			lineRenderer.SetPosition(i, nextPos);
		}
	}

	void OnTriggerEnter(Collider other) {
		ParticlesCreator.CreateDebrisParticles(gameObject.transform.position);

		// audio.PlayOneShot(audioClip, 0.7f);
		
		SatellitesManager.Instance.SelectNextSatellite();
		SatellitesManager.Instance.RemoveSatellite(gameObject);
		Destroy(gameObject);
	}

}

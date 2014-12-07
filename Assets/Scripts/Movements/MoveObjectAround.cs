using UnityEngine;
using System.Collections;

public class MoveObjectAround : MonoBehaviour {

	public float speed;
	public Transform target;

	public Color c1 = Color.yellow;

    private LineRenderer lineRenderer;
    private int numLineSegments = 18;

    private void Start() {
		lineRenderer = gameObject.AddComponent<LineRenderer>();

		float theta_scale = 0.1f;
		int size = (int)((2.0f * Mathf.PI) / theta_scale);

		lineRenderer.material = new Material(Shader.Find("Particles/Additive"));
		lineRenderer.SetColors(c1, c1);
		lineRenderer.SetWidth(0.2f, 0.2f);
		lineRenderer.SetVertexCount(numLineSegments + 1);

    }
	
	private void Update() {
		transform.RotateAround(target.position, transform.right, speed * Time.deltaTime);

		Vector3 up = transform.up;
		float distanceToCenter = Vector3.Distance(transform.position, target.position);
		
		float step = 360.0f / numLineSegments;
		for (int i = 0; i < numLineSegments + 1; ++i) {
			Vector3 rotatedUp = Quaternion.AngleAxis(step * i, transform.right) * transform.up;
			Vector3 nextPos = target.position + rotatedUp * distanceToCenter;
			lineRenderer.SetPosition(i, nextPos);
		}
	}

}

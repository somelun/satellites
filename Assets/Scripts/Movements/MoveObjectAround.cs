using UnityEngine;
using System.Collections;

public class MoveObjectAround : MonoBehaviour {

	public float speed;
	public Transform target;

	// public Color c1 = Color.yellow;
 //    public Color c2 = Color.red;
 //    public int lengthOfLineRenderer = 200;

    void Start() {
        // LineRenderer lineRenderer = gameObject.AddComponent<LineRenderer>();
        // lineRenderer.material = new Material(Shader.Find("Particles/Additive"));
        // lineRenderer.SetColors(c1, c2);
        // lineRenderer.SetWidth(0.2F, 0.2F);
        // lineRenderer.SetVertexCount(lengthOfLineRenderer);
    }
	
	private void Update() {
		transform.RotateAround(target.position, Vector3.up, speed * Time.deltaTime);

		// LineRenderer lineRenderer = GetComponent<LineRenderer>();
  //       int i = 0;
  //       while (i < lengthOfLineRenderer) {
  //           Vector3 pos = new Vector3(i * 0.5F, Mathf.Sin(i + Time.time), 0);
  //           lineRenderer.SetPosition(i, pos);
  //           i++;
  //       }
	}

}

using UnityEngine;
using System.Collections;


public class SatelliteLogic : MonoBehaviour {
	public float _speed = 20.0f;
	public float _orbitHeight = 4.0f;
	
	private GameObject _planet;

	void Start () {
		_planet = GameObject.FindGameObjectsWithTag("Planet")[0];
	}
	
	void Update() {
        transform.RotateAround(_planet.transform.position, Vector3.up, _speed * Time.deltaTime);
    }
}

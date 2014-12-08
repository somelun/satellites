using UnityEngine;
using System.Collections;

public class ParticlesCreator : MonoBehaviour {

	public static void CreateDebrisParticles(Vector3 position) {
        Instantiate(Constants.particleSystem, position, Quaternion.identity);
	}
	
}

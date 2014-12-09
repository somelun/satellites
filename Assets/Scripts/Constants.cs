using UnityEngine;

public class Constants {

	// materials
	public static Material normalMaterial = (Material)Resources.Load("Materials/SatelliteMaterial", typeof(Material));
	public static Material selectedMaterial = (Material)Resources.Load("Materials/SelectedSatelliteMaterial", typeof(Material));
	public static Material destroyedMaterial = (Material)Resources.Load("Materials/DestroyedSatelliteMaterial", typeof(Material));
	public static Material lineMaterial = (Material)Resources.Load("Materials/LineMaterial", typeof(Material));

	//particle systems
	public static ParticleSystem particleSystem = (ParticleSystem)Resources.Load("Particles/Debris", typeof(ParticleSystem));

	// audio clips
	public static AudioClip hitAudioAcip = (AudioClip)Resources.Load("Sounds/Hit_Hurt", typeof(AudioClip));
	public static AudioClip bgTrack = (AudioClip)Resources.Load("Sounds/gamejam", typeof(AudioClip));

}

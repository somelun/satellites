using UnityEngine;

public class Constants {
	public static Material normalMaterial = (Material)Resources.Load("Materials/SatelliteMaterial", typeof(Material));
	public static Material selectedMaterial = (Material)Resources.Load("Materials/SelectedSatelliteMaterial", typeof(Material));
	public static Material destroyedMaterial = (Material)Resources.Load("Materials/DestroyedSatelliteMaterial", typeof(Material));
}

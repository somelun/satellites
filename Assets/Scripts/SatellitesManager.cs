using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SatellitesManager {

	protected SatellitesManager() {}

	private static SatellitesManager _instance = null;

	private List<GameObject> satellites = new List<GameObject>();

	public static SatellitesManager Instance { 
		get {
        	if(SatellitesManager._instance == null) {
        		SatellitesManager._instance = new SatellitesManager();
        	}
        	return SatellitesManager._instance;
    	}
    }

    public void AddSatellite(GameObject satellite) {
    	satellites.Add(satellite);
    }

}

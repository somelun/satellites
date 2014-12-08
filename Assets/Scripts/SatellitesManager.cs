﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SatellitesManager {

	protected SatellitesManager() {}
	private static SatellitesManager _instance = null;

	private List<GameObject> satellites = new List<GameObject>();
	private int currentSatelliteIndex;

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

    public void SelectNextSatellite() {
    	GameObject currentSatellite = satellites[currentSatelliteIndex];
    	currentSatellite.renderer.sharedMaterial = Constants.normalMaterial;

    	currentSatelliteIndex = currentSatelliteIndex + 1;
    	if (currentSatelliteIndex >= satellites.Count) {
    		currentSatelliteIndex = 0;
    	}
    	currentSatellite = satellites[currentSatelliteIndex];
    	currentSatellite.renderer.sharedMaterial = Constants.selectedMaterial;
    }

    public GameObject SelectedSatellite() {
    	return satellites[currentSatelliteIndex];
    }

}

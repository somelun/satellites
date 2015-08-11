using UnityEngine;
using System.Collections;

public class Restarter : MonoBehaviour {

	private float w = 300.0f;
	private float h = 150.0f;

	private void OnGUI() {

    	if(GUI.Button(new Rect(Screen.width / 2 - w / 2, Screen.height / 2 - h / 2, w, h), "Important satellites were destroyed. \n\nPress to restart.")){
        	Application.LoadLevel("GameScene");
    	}
	}

}

using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MenuButtons : MonoBehaviour {

	public void PlayButtonClick() {
		Destroy(GameObject.Find("Button"));
	}

	public void RestartButtonClick() {
		Application.LoadLevel("GameScene");
	}
	
}

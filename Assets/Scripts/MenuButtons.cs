using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuButtons : MonoBehaviour {

	public void PlayButtonClick() {
		Destroy(GameObject.Find("Button"));
	}

	public void RestartButtonClick() {
		SceneManager.LoadScene("GameScene", LoadSceneMode.Single);
	}
	
}

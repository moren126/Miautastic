using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour {

	public void BackToMenuButton() {
		SceneManager.LoadScene ("menu");
	}

	public void ExitButton() {
		Application.Quit ();
	}

}

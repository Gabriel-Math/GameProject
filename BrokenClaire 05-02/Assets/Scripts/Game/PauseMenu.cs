using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour {

	public static bool GameIsPaused = false;
	Controller pl;

	public GameObject pauseMenuUI;

	void Start() {
		pl = GameObject.FindGameObjectWithTag ("Player").GetComponent<Controller> ();
		pauseMenuUI.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Escape)) {
			if (GameIsPaused) {
				Resume ();
				Debug.Log ("Resumiu");
			} else if(!GameIsPaused) {
				Pause ();
				Debug.Log ("Pausou");
			}
		}
	}

	public void Resume() {
		pauseMenuUI.SetActive (false);
		Time.timeScale = 1f;
		GameIsPaused = false;
		//Cursor.visible = false;
		pl.enabled = true;
	}

	void Pause() {
		pauseMenuUI.SetActive (true);
		Time.timeScale = 0f;
		GameIsPaused = true;
		//Cursor.visible = true;
		pl.enabled = false;
	}

	public void LoadMenu() {
		Debug.Log ("Carregar menu");
		SceneManager.LoadScene ("Main_Menu");
	}

	public void QuitGame() {
		Debug.Log ("Saindo do jogo");
		Application.Quit ();
	}
}

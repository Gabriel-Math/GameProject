using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Notes : MonoBehaviour {

	public string noteName;
	public bool noteReading = false;

	GameObject note;
	Controller pl;

	void Start () {
		pl = GameObject.FindGameObjectWithTag ("Player").GetComponent<Controller> ();
		note = GameObject.Find (noteName);
		note.SetActive (false);
	}


	void Update() {
		if (Input.GetKeyUp (KeyCode.E) && noteReading) {
			note.SetActive (!note.activeSelf);

			if (noteReading && note.activeSelf == true) {
				Debug.Log ("Abriu a nota");
				ShowNote ();
			} else {
				Debug.Log ("Fechou a nota");
				HideNote ();
				noteReading = false;
			}
		}
	}
		
	void ShowNote() {
		Time.timeScale = 0f;
		pl.enabled = false;
	}

	void HideNote() {
		Time.timeScale = 1f;
		pl.enabled = true;
	}
}

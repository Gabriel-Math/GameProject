using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Interaction : MonoBehaviour {

	public float interactionDistance = 1f;
	public GameObject interactionText;
	public GameObject lockedText;

	void Start() {
		interactionText.SetActive (false);
		lockedText.SetActive (false);
	}

	void Update () {
		Ray ray = new Ray (transform.position, transform.forward);
		RaycastHit hit;

		if (Physics.Raycast (ray, out hit, interactionDistance)) {

			if (hit.collider.CompareTag ("Door")) {
				Door doorScript = hit.collider.transform.parent.GetComponent<Door> ();
				interactionText.SetActive (true);
				if (Inventory.keys [doorScript.index] == false) {
					interactionText.SetActive (false);
					lockedText.SetActive (true);
				}
			} else if(hit.collider.CompareTag ("Key") || hit.collider.CompareTag ("Note")) {
				interactionText.SetActive (true);
			}

			if (Input.GetKeyDown (KeyCode.E)) {
				if (hit.collider.CompareTag ("Door")) {
					Door doorScript = hit.collider.transform.parent.GetComponent<Door> ();
					if (Inventory.keys [doorScript.index] == true) {
						Debug.Log ("Interagiu com a porta");
						doorScript.ChangeDoorState ();
					}
				}

				if (hit.collider.CompareTag ("Key")) {
					Debug.Log ("Coletou a chave");
					Inventory.keys [hit.collider.GetComponent<Key> ().index] = true;
					FindObjectOfType<AudioManager> ().Play ("KeyGet");
					Destroy (hit.collider.gameObject);
				}

				if (hit.collider.CompareTag ("Note")) {
					Debug.Log ("Coletou a nota");
					Notes note = hit.collider.GetComponent<Notes> ();
					note.noteReading = true;
				}
			}
		} else {
			interactionText.SetActive (false);
			lockedText.SetActive (false);
		}
	}
}

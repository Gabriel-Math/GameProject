using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Door : MonoBehaviour {

	public int index = -1;
	public bool open = false;
	public float doorOpenAngle = 90f;
	public float doorCloseAngle = 0f;
	public float smooth = 2f;
	public NavMeshObstacle obs;

	void Start() {
		obs = this.GetComponent<NavMeshObstacle> ();
	}

	public void ChangeDoorState() {
		open = !open;
		if(open == false)
			FindObjectOfType<AudioManager> ().Play ("DoorOpen");
		else
			FindObjectOfType<AudioManager> ().Play ("DoorClose");
	}

	void Update () {

		if (open) {
			Quaternion targetRotation = Quaternion.Euler (0, doorOpenAngle, 0);
			transform.localRotation = Quaternion.Slerp (transform.localRotation, targetRotation, smooth * Time.deltaTime);
		} else {
			Quaternion targetRotation2 = Quaternion.Euler (0, doorCloseAngle, 0);
			transform.localRotation = Quaternion.Slerp (transform.localRotation, targetRotation2, smooth * Time.deltaTime);
		}
			
		if (Inventory.keys [index] == true) {
			obs.enabled = false;
		} else if (Inventory.keys [index] == false) {
			obs.enabled = true;
		}
	}

	void OnTriggerEnter(Collider other) {
		if (other.tag == "enemy") {
			if (open == false) {
				StartCoroutine ("enemyOpenClose", 5f);
				other.GetComponent<NavMeshAgent> ().speed = 1.5f;
			}
		}
	}

	void OnTriggerExit(Collider other) {
		if (other.tag == "enemy") {
			if (open == true) {
				other.GetComponent<NavMeshAgent> ().speed = 2.5f;
			}
		}
	}


	IEnumerator enemyOpenClose() {
		ChangeDoorState ();
		yield return new WaitForSeconds (1);
	}
}

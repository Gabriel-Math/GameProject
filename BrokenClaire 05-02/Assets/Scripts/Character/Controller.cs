using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class Controller : MonoBehaviour {

	public float movementSpeed;
	public bool hide = false;
	public GameObject camera;
	public GameObject playerObj;
	Animator anim;

	private float vR = 100f;
	private float vA = 150f;

	FieldOfView fov;

	void Start() {
		fov = this.GetComponent<FieldOfView> ();
		anim = GetComponentInChildren<Animator>();
	}

	void Update() {
		Plane playerPlane = new Plane (Vector3.up, transform.position);
		Ray ray = UnityEngine.Camera.main.ScreenPointToRay (Input.mousePosition);
		float hitDst = 0f;

		if (playerPlane.Raycast (ray, out hitDst)) {
			Vector3 targetPoint = ray.GetPoint (hitDst);
			Quaternion targetRotation = Quaternion.LookRotation (targetPoint - transform.position);
			targetRotation.x = 0;
			targetRotation.z = 0;
			playerObj.transform.rotation = Quaternion.Slerp (playerObj.transform.rotation, targetRotation, 7f * Time.deltaTime);
		}

		if (Input.GetKey (KeyCode.W) || Input.GetKey (KeyCode.UpArrow)) {
			transform.Translate (Vector3.forward * movementSpeed * Time.deltaTime);
			anim.SetBool ("IsWalking", true);
		}
		if (Input.GetKey (KeyCode.S) || Input.GetKey (KeyCode.DownArrow)) {
			transform.Translate (Vector3.back * movementSpeed * Time.deltaTime);
			anim.SetBool ("IsWalking", true);
		}
		if (Input.GetKey (KeyCode.A) || Input.GetKey (KeyCode.LeftArrow)) {
			transform.Translate (Vector3.left * movementSpeed * Time.deltaTime);
			anim.SetBool ("IsWalking", true);
		}
		if (Input.GetKey (KeyCode.D) || Input.GetKey (KeyCode.RightArrow)) {
			transform.Translate (Vector3.right * movementSpeed * Time.deltaTime);
			anim.SetBool ("IsWalking", true);
		}

		if(!Input.GetKey (KeyCode.W) && !Input.GetKey (KeyCode.S) && !Input.GetKey (KeyCode.A) && !Input.GetKey (KeyCode.D) && !Input.GetKey (KeyCode.UpArrow) && !Input.GetKey (KeyCode.DownArrow) && !Input.GetKey (KeyCode.LeftArrow) && !Input.GetKey (KeyCode.RightArrow))
			anim.SetBool ("IsWalking", false);

		if (hide) {
			fov.viewRadius = Mathf.SmoothDamp (fov.viewRadius, 10,ref vR, 1);
			fov.viewAngle = Mathf.SmoothDamp (fov.viewAngle, 40, ref vA, 1);
		} 
		if (!hide) {
			fov.viewRadius = Mathf.SmoothDamp (fov.viewRadius, 20,ref vR, 1);
			fov.viewAngle = Mathf.SmoothDamp (fov.viewAngle, 120, ref vA, 1);
		}

	}

	void OnTriggerEnter(Collider other) {
		if (other.tag == "hidePlace") {
			hide = true;
			FindObjectOfType<AudioManager> ().Play ("Hide");
			Debug.Log ("Escondido");
		}
	}

	void OnTriggerExit (Collider other) {
		if (other.tag == "hidePlace") {
			hide = false;
			FindObjectOfType<AudioManager> ().Stop ("Hide");
			Debug.Log ("Visivel");
		}
	} 
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillerIA : MonoBehaviour {

	Animator anim;
	public GameObject player;
	public float hideDistance = 5;
	enemyFieldOfView fov;

	public GameObject GetPlayer() {
		return player;
	}

	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> ();
		fov = gameObject.GetComponent<enemyFieldOfView> ();
	}
	
	// Update is called once per frame
	void Update () {
		anim.SetFloat ("distance", Vector3.Distance (transform.position, player.transform.position));

		if (anim.GetFloat ("distance") > hideDistance)
			anim.SetBool ("hide", GameObject.Find ("Player").GetComponent<Controller> ().hide);

		if (player.GetComponent<Controller> ().hide == false && fov.canSee == true) {
			anim.SetBool ("canSee", true);
		} else {
			anim.SetBool ("canSee", false);
		}
	}
} 

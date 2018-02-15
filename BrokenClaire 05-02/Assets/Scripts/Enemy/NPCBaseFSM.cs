using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCBaseFSM : StateMachineBehaviour {

	public GameObject NPC;
	public UnityEngine.AI.NavMeshAgent agent;
	public GameObject opponent;
	public float speed = 2.5f;
	public float rotSpeed = 1.0f;
	public float accuracy = 3.0f;

	override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
		NPC = animator.gameObject;
		opponent = NPC.GetComponent<KillerIA> ().GetPlayer ();
		agent = NPC.GetComponent<UnityEngine.AI.NavMeshAgent> ();
	}
}

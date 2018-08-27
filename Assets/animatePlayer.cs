using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animatePlayer : MonoBehaviour {

	private Animator animator;
	private bool flying;
	private bool grounded;
	public GameObject movementBox;

	// Use this for initialization
	void Start () {
		animator = gameObject.GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		flying = movementBox.GetComponent<playerControler>().GetFlying();
		grounded = movementBox.GetComponent<playerControler>().GetIsGrounded();
		if (grounded == false || flying == true)
		{
			animator.SetBool("grounded", false);
		}
		else{
			animator.SetBool("grounded", true);
		}

		
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animatePlayer : MonoBehaviour {

	private Animator animator;
	private bool grounded;
	public GameObject movementBox;

	// Use this for initialization
	void Start () {
		animator = gameObject.GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		grounded = movementBox.GetComponent<playerControler>().GetIsGrounded();
		if (grounded == true)
		{
			animator.SetBool("grounded", true);
		}
		else{
			animator.SetBool("grounded", false);
		}

		
	}
}

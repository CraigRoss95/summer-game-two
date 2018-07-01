using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shoot : MonoBehaviour {

	public GameObject screen;
	public GameObject projectile;
	public GameObject emitter;
	public float cooldownTime;
	public float speed;
	private bool onCooldown;
	private GameObject clone;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		if(onCooldown == false && Input.GetButton("Fire1"))
		{
			clone = Instantiate(projectile, emitter.transform.position,emitter.transform.rotation);
			clone.GetComponent<Rigidbody>().AddForce(transform.forward * speed);
			clone.transform.parent = screen.transform;
			onCooldown = true;
			Invoke("PutOffCoolDown", cooldownTime);
		}
		
	}
	void PutOffCoolDown()
	{
		onCooldown = false;
	}
}

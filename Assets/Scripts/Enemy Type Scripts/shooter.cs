using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shooter : MonoBehaviour {


	public float distance;
	public float time;

	private bool inPosition;

	private bool activated;
	public GameObject bullet;

	private GameObject player;
	private GameObject screen;

	public float cooldownTime;
	public float bulletSpeed;
	private bool onCooldown;
	private GameObject clone;
	// Use this for initialization
	void Start () {
			onCooldown = false;
			inPosition = false;
			screen = GameObject.Find("moving screen");
			player = GameObject.Find("movement box");
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(gameObject.GetComponent<enemyHealth>().GetActivated() == true)
		{
			if(inPosition == false)
			{
				transform.Translate(Vector3.left * (distance/time) * Time.deltaTime);
				Invoke("PutInPosition", time);
			}
			else
			{
				transform.parent = screen.transform;
				transform.LookAt(player.transform);
				if (onCooldown == false)
				{
					Debug.Log("egg");
					clone = Instantiate(bullet, gameObject.transform.position, gameObject.transform.rotation);
					
					clone.GetComponent<Rigidbody>().AddForce(transform.forward * bulletSpeed);
					clone.transform.parent = screen.transform;
					onCooldown = true;
					Invoke("TakeOffCooldown", cooldownTime);
				}
				
				
					
			}
		}	
	}
	void PutInPosition()
	{
		inPosition = true;
	}	
	void TakeOffCooldown()
	{
		onCooldown = false;
	}

	void OnTriggerEnter (Collider thing)
	{

	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class squidScript : MonoBehaviour {

private GameObject player;
	public float speed;

	private bool activated;
	private GameObject screen;
	public float stillTime;
	public float moveTime;
	private bool moveing;
	public float turningSpeed;
	public GameObject rotator;
	public GameObject model;

	// Use this for initialization
	void Start () {
			screen = GameObject.Find("moving screen");
			player = GameObject.Find("movement box");
			moveing = true;
			Invoke("Turn", moveTime);
			gameObject.transform.LookAt(player.transform);
	}
	
	// Update is called once per frame
	void Update () 
	{
		gameObject.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y,0);

		rotator.transform.LookAt(player.transform);
		if (GetComponent<enemyHealth>().GetActivated() == true)
		{
			transform.parent = screen.transform;
			if(moveing == true)
			{
				transform.Translate(Vector3.forward * speed * Time.deltaTime);
			}
			else
			{
				//transform.LookAt(player.transform);
				transform.rotation = Quaternion.RotateTowards(transform.rotation, rotator.transform.rotation, turningSpeed * Time.deltaTime);

				//Debug.Log("logging " + hold);
			}
			
		}
		
	}
	void Move()
	{
		moveing = true;
		Invoke("Turn", moveTime);
	}

	void Turn()
	{
		moveing = false;
		Invoke("Move", stillTime);
	}

	void OnTriggerEnter (Collider thing)
	{
		if(thing.transform.tag == "player")
		{
			Destroy(gameObject);
		}
	}
}

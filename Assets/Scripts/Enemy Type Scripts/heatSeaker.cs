using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class heatSeaker : MonoBehaviour {

	private GameObject player;
	public float speed;

	private bool activated;
	private GameObject screen;
	// Use this for initialization
	void Start () {
			screen = GameObject.Find("moving screen");
			player = GameObject.Find("player");
	}
	
	// Update is called once per frame
	void Update () {
		if (GetComponent<enemyHealth>().GetActivated() == true)
		{
			transform.parent = screen.transform;
			transform.LookAt(player.transform);
			transform.Translate(Vector3.forward * speed * Time.deltaTime);
		}
		
	}

	void OnTriggerEnter (Collider thing)
	{
		if(thing.transform.tag == "player")
		{
			Destroy(gameObject);
		}
	}
}

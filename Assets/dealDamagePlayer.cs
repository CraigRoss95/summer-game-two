using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dealDamagePlayer : MonoBehaviour {
	public int damage;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () 
	{

	}
	
	void OnTriggerEnter(Collider thing)
	{
		if(thing.transform.tag == "player")
		{
			thing.GetComponent<playerHealth>().TakeDamage(damage);
			Debug.Log("reeeee");
		}
	}
	
}

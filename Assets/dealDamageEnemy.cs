using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dealDamageEnemy : MonoBehaviour {

	public int damage;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter(Collider thing)
	{
		if(thing.transform.tag == "enemy")
		{
			thing.GetComponent<enemyHealth>().TakeDamage(damage);
		}
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class enemyHealth : MonoBehaviour {

	public int health;
	public int maxHealth;
	// Use this for initialization
	void Start () {
		health = maxHealth;
	}
	
	// Update is called once per frame
	void Update () {
		if (health <= 0)
		{
			Destroy(gameObject);
		}
		
	}

	public void TakeDamage (int damage)
	{
		health = health - damage;
	}
}

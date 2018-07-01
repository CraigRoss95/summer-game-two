using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class enemyHealth : MonoBehaviour {

	public bool activated;
	public int health;
	public int maxHealth;
	// Use this for initialization
	void Start () {
		health = maxHealth;
		activated = false;
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
		if(activated == true)
		{
			health = health - damage;
		}
		
	}
	public void Activate()
	{
		activated = true;
	}
	public bool GetActivated()
	{
		return activated;
	}
}

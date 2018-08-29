using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class enemyHealth : MonoBehaviour {

	public bool activated;
	public int health;
	public int maxHealth;
	public AudioSource audioSource;
	public AudioClip Death;
	public bool isBossPart;
	public GameObject boss;


	// Use this for initialization
	void Start () {
		health = maxHealth;
		activated = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (health <= 0)
		{
			AudioSource deathsound = Instantiate(audioSource,gameObject.transform.position,gameObject.transform.rotation);
			Destroy(gameObject);
		}
		
	}

	public void TakeDamage (int damage)
	{
		if(activated == true)
		{
			if(isBossPart == true)
			{
				boss.GetComponent<enemyHealth>().TakeDamage(damage);
			}
			else{
				health = health - damage;
			}
			
		}
		
	}
	public int GetHealth()
	{
		return health;
	}
	public void Activate()
	{
		activated = true;
	}
	public bool GetActivated()
	{
		return activated;
	}
	public int GetMaxHealth()
	{
		return maxHealth;
	}
}

﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerHealth : MonoBehaviour {
public int maxHealth;
public int currHealth;
	// Use this for initialization
	void Start () {
		currHealth = maxHealth;
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (currHealth <= 0)
		{
			gameObject.SetActive(false);
			gameObject.transform.parent.GetComponent<moveScreen>().Stop();
		}	
	}
	public void TakeDamage(int damage)
	{
		currHealth = currHealth - damage;
	}
}
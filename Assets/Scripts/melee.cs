﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class melee : MonoBehaviour {

private bool onCooldown;
private bool meleeing;

public GameObject meleeHitbox;
public float swordOutTime;
public float cooldownTime;
public AudioSource audioSource;
public AudioClip swordSound;

	// Use this for initialization
	void Start () {
		onCooldown = false;
		meleeing = false;
	}
	
	// Update is called once per frame
	void MeleeOutCheck () {

		if (meleeing == false)
		{
			meleeHitbox.SetActive(false);
		}
		else{
			meleeHitbox.SetActive(true);
		}
	}
	void Update()
	
	{
		MeleeOutCheck();
		if(Input.GetButtonDown("melee") && onCooldown == false && meleeing == false)
		{
			audioSource.PlayOneShot(swordSound);
			meleeing = true;
			Invoke("SwordOutInvoke", swordOutTime);
		}
		
	}
	void SwordOutInvoke()
	{
		meleeing = false;
		onCooldown = true;
		Invoke("TakeOffCooldown", cooldownTime);
	}

	void TakeOffCooldown()
	{
		onCooldown = false;
	}
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dodge : MonoBehaviour {

private bool onCooldown;
private bool dodgeing;
public float dodgeTime;
public float cooldownTime;
	// Use this for initialization
	void Start () {
		onCooldown = false;
		dodgeing = false;
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetButtonDown("dodge") && onCooldown == false && dodgeing == false)
		{
			Dodge();
		}
	}

void Dodge()
	{
		dodgeing = true;
		gameObject.GetComponent<BoxCollider>().enabled = false;
		Invoke("UnDodge", dodgeTime);
	}
void UnDodge()
	{
		dodgeing = false;
		gameObject.GetComponent<BoxCollider>().enabled = true;
		onCooldown = true;
		Invoke ("Cooldown", cooldownTime);

	}
void Cooldown()
{
	onCooldown = false;
}
}

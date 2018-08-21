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
		if (Input.GetButtonDown("dodge") && onCooldown == false && dodgeing == false && gameObject.GetComponent<playerHealth>().GetInvinsable() == true)
		{
			Dodge();
		}
		if(gameObject.GetComponent<playerHealth>().GetInvinsable() == true)
		{
			gameObject.GetComponent<BoxCollider>().enabled = false;
		}
		else{
			gameObject.GetComponent<BoxCollider>().enabled = true;
		}
	}

void Dodge()
	{
		dodgeing = true;
		
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

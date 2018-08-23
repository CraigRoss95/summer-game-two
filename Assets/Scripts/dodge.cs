using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dodge : MonoBehaviour {

private bool onCooldown;
private bool dodgeing;
public float dodgeTime;
public float cooldownTime;
public GameObject playerModel;
public Material dodgeingTexture;
private Material notDodgeingTexture;
public GameObject animationTarget;
private Animator animator;
	// Use this for initialization
	void Start () {
		animator = animationTarget.GetComponent<Animator>();
		onCooldown = false;
		dodgeing = false;
		notDodgeingTexture = playerModel.GetComponent<Renderer>().material;
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetButtonDown("dodge") && onCooldown == false && dodgeing == false && gameObject.GetComponent<playerHealth>().GetInvinsable() == false)
		{	animator.Play("dodge");
			Dodge();
		}
		if(dodgeing == false)
		{
			if(gameObject.GetComponent<playerHealth>().GetInvinsable() == true)
			{
				gameObject.GetComponent<BoxCollider>().enabled = false;
			}
			else
			{
				gameObject.GetComponent<BoxCollider>().enabled = true;
			}
		}
		
	}

void Dodge()
	{
		dodgeing = true;
		playerModel.GetComponent<Renderer>().material = dodgeingTexture;
		gameObject.GetComponent<BoxCollider>().enabled = false;
		Invoke("UnDodge", dodgeTime);
	}
void UnDodge()
	{
		dodgeing = false;
		gameObject.GetComponent<BoxCollider>().enabled = true;
		onCooldown = true;
		playerModel.GetComponent<Renderer>().material = notDodgeingTexture;
		
		
		Invoke ("Cooldown", cooldownTime);

	}

public bool GetIsDodgeing()
	{
		return dodgeing;
	}
	
void Cooldown()
{
	onCooldown = false;
}
}

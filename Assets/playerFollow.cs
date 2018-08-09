using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerFollow : MonoBehaviour {
public Transform target;
public float followSpeed;
public float invokeTime;
public float yOffset;
public float groundYOffset;
public float followSpeedFactor;
private bool ground;
	// Use this for initialization
	void Start () {
	ground = false;
	}
	
	// Update is called once per frame
	void Update () {
		if(target.gameObject.GetComponent<playerControler>().GetIsGrounded() == true)
		{
			if (ground == false)
			{
				ground = true;
				target.transform.position = new Vector3 (gameObject.transform.position.x,gameObject.transform.position.y,target.transform.position.z);
			}
			transform.position = Vector3.Lerp(transform.position,new Vector3 (target.transform.position.x,target.transform.position.y + groundYOffset, target.transform.position.z), Time.deltaTime * followSpeed * followSpeedFactor);
			
		}
		else
		{
			ground = false;
			transform.position = Vector3.Lerp(transform.position,new Vector3 (target.transform.position.x,target.transform.position.y + yOffset, target.transform.position.z), Time.deltaTime * followSpeed);
		}
	}
}

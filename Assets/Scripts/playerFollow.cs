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
private bool flying;
	// Use this for initialization
	void Start () {
		flying = target.GetComponent<playerControler>().GetFlying();
	}
	
	// Update is called once per frame
	void Update () {
		if(target.gameObject.GetComponent<playerControler>().GetFlying() == false)
		{
			if(flying == true && target.gameObject.GetComponent<playerControler>().GetFlying() == false)
			{
				target.GetComponent<Rigidbody>().velocity = Vector3.zero;
				target.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
				target.transform.position = gameObject.transform.transform.position + new Vector3(0,-yOffset,0);
				flying = false;
			}
			transform.position = Vector3.Lerp(transform.position,new Vector3 (target.transform.position.x,target.transform.position.y + groundYOffset, target.transform.position.z), Time.deltaTime * followSpeed * followSpeedFactor);
		}
		else
		{
			flying = true;
			transform.position = Vector3.Lerp(transform.position,new Vector3 (target.transform.position.x,target.transform.position.y + yOffset, target.transform.position.z), Time.deltaTime * followSpeed);
		}
	}
}

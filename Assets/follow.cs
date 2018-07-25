using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class follow : MonoBehaviour {
public Transform target;
public float followSpeed;
public float invokeTime;
public float yOffset;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		transform.position = Vector3.Lerp(transform.position,new Vector3 (target.transform.position.x,target.transform.position.y + yOffset, target.transform.position.z), Time.deltaTime * followSpeed);
		
	}
	
}

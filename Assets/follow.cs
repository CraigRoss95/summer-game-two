using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class follow : MonoBehaviour {
public Transform target;
public float followSpeed;
public float invokeTime;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		transform.position = Vector3.Lerp(transform.position,target.transform.position, Time.deltaTime * followSpeed);
		
	}
	
}

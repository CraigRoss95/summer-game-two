using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class touchingGround : MonoBehaviour {

	private bool touching;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	void OnTriggerEnter( Collider thing)
	{
		if (thing.transform.tag == "ground")
		{
			touching = true;
		}
	}	void OnTriggerStay( Collider thing)
	{
		if (thing.transform.tag == "ground")
		{
			touching = true;
		}
	}
	void OnTriggerExit( Collider thing)
	{
		if (thing.transform.tag == "ground")
		{
			touching = false;
		}
	}
	public bool GetTouching()
	{
		return touching;
	}
}

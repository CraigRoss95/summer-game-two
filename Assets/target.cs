using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class target : MonoBehaviour {

	public string dammageTag;
	public GameObject screen;
	public bool isStatic;
	// Use this for initialization
	void Start () {
		if(isStatic == false)
		{
			transform.parent = screen.transform;
		}
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}

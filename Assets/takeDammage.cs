using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class takeDammage : MonoBehaviour {

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
	
	void OnTriggerEnter(Collider hit)
	{
		if (hit.tag == dammageTag)
		{
			Destroy(hit.gameObject);
			gameObject.GetComponent<enemyHealth>().TakeDamage(1);
		}
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroy : MonoBehaviour {

	public float destroyIn;
	// Use this for initialization
	void Start () {
		Invoke("DestroyMe", destroyIn);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	void DestroyMe()
	{
		Destroy(gameObject);
	}

	void OnTriggerEnter(Collider thing)
	{
		if(thing.tag == "bulletStopper")
		{
			Destroy(gameObject);
		}
	}
}

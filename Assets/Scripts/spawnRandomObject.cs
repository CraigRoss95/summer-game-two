using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnRandomObject : MonoBehaviour {

	public float maxTime;
	public float minTime;

	public GameObject thing;
	public float maxup;
	public float maxdown;
	// Use this for initialization
	void Start () {
		Invoke("SpawnThing", Random.Range(minTime,maxTime));
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	void SpawnThing()
	{
		Instantiate(thing,transform.position +new Vector3(0,Random.Range(maxdown,maxup),0),transform.rotation);
		Invoke("SpawnThing", Random.Range(minTime,maxTime));
	}
}

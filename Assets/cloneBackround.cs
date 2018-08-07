using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cloneBackround : MonoBehaviour {

	public GameObject plane;
	public float delay;
	public float offsetDistance;


	// Use this for initialization
	void Start () {
		gameObject.transform.SetParent(GameObject.Find("moving screen").transform);
		Invoke("SpawnPannle", delay);
	}
	
	// Update is called once per frame
	void Update () {

		
	}
	void SpawnPannle()
	{
		Instantiate(plane,(gameObject.transform.position + new Vector3(offsetDistance,0,0)),gameObject.transform.rotation);
	}
}

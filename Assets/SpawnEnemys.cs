using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemys : MonoBehaviour {

public GameObject spawner;
public GameObject sampleChunk;
public float maxYChange;
public float minYChange;
public float maxWaitTime;
public float minWaitTime;
	// Use this for initialization
	void Start () {
			StartCoroutine(Spawn());
		
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	IEnumerator Spawn(){
		Instantiate(sampleChunk, spawner.transform.position + new Vector3(0,Random.Range(minYChange,maxYChange),0), spawner.transform.rotation);
		yield return new WaitForSeconds(Random.Range(minWaitTime,maxWaitTime));	
		StartCoroutine(Spawn());

	}
}

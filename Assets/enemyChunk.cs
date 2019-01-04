using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyChunk : MonoBehaviour {

	public GameObject[] nodes;
	public GameObject[] enemys;

	// Use this for initialization
	void Start () {
		for(int i = 0; i < nodes.Length; i++)
		{
		Instantiate(enemys[Random.Range(0,enemys.Length)],nodes[i].transform.position,nodes[i].transform.rotation);
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lazerStartFollow : MonoBehaviour {

private GameObject player;
	// Use this for initialization
	void Start () {
		player = GameObject.Find("player (1)");
		
	}
	
	// Update is called once per frame
	void Update () {
		gameObject.GetComponent<LineRenderer>().SetPosition(0,player.transform.position);
	}
}

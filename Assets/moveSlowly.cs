using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveSlowly : MonoBehaviour {
public float speed;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		gameObject.transform.Translate(Vector3.right * speed * Time.deltaTime);
	}
}

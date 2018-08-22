using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class chunk : MonoBehaviour {
public Transform end;
public Transform start;
public GameObject thisChunk;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	}
	public Transform GetEnd()
	{
		return end;
	}
	public Transform GetStart()
	{
		return start;
	}
	public float GetChunkLength()
	{
		return Vector3.Distance(start.position, end.position);
	}
}

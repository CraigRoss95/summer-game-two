using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class score : MonoBehaviour {

public int currentScore;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	public void AddScore(int newScore)
	{
		currentScore += newScore;
	}
}

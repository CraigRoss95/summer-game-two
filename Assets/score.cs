using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class score : MonoBehaviour {

public Text scoreText;
public int currentScore;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		scoreText.text = "Score: " + currentScore.ToString();
	}

	public void AddScore(int newScore)
	{
		currentScore += newScore;
	}
}

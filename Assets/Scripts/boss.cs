using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class boss : MonoBehaviour {

private bool awoken;
private GameObject canvas;
	// Use this for initialization
	void Start () 
			{
				canvas = GameObject.Find("Canvas");
				awoken = false;
			}
	
	// Update is called once per frame
	void Update () 
	{
		if (awoken == false && gameObject.GetComponent<enemyHealth>().GetActivated() == true)
		{
			canvas.GetComponent<BossHPUI>().SetUpBoss(gameObject);
			awoken = true;
		}
	}
}

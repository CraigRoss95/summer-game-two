using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class boss : MonoBehaviour {

public Slider bossHP;
	// Use this for initialization
	void Start () 
			{
				bossHP.gameObject.SetActive(false);
			}
	
	// Update is called once per frame
	void Update () {
		if(gameObject.GetComponent<enemyHealth>().GetActivated() == true)
		{
			
		
		if (gameObject.GetComponent<enemyHealth>().GetHealth() > 0 )
		{
			 bossHP.value = gameObject.GetComponent<enemyHealth>().GetHealth();
			bossHP.gameObject.SetActive(true);
		}
		else{
			bossHP.gameObject.SetActive(false);
		}

	}
	}
}

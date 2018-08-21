using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class boss : MonoBehaviour {

public Slider bossHP;
public Text HPText;
	// Use this for initialization
	void Start () 
			{
				bossHP.gameObject.SetActive(false);
				HPText.gameObject.SetActive(false);
				bossHP.maxValue = gameObject.GetComponent<enemyHealth>().GetHealth();
				HPText.text = "" + gameObject.GetComponent<enemyHealth>().GetHealth();
			}
	
	// Update is called once per frame
	void Update () {
		if(gameObject.GetComponent<enemyHealth>().GetActivated() == true)
		{
			// having the 1 there is a temp fix get back to this later (it should be a zero)
		if (gameObject.GetComponent<enemyHealth>().GetHealth() > 1 )
		{
			HPText.text = "" + gameObject.GetComponent<enemyHealth>().GetHealth();
			 bossHP.value = gameObject.GetComponent<enemyHealth>().GetHealth();
			 HPText.gameObject.SetActive(true);
			bossHP.gameObject.SetActive(true);
		}
		else
		{
			HPText.gameObject.SetActive(false);
			bossHP.gameObject.SetActive(false);
		}

	}
}
}

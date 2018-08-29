using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossHPUI : MonoBehaviour {

public Slider bossHP;
public Text HPText;
public GameObject currentBoss;
private bool bossActive;
	// Use this for initialization
	void Start () 
			{
				bossActive = false;
				bossHP.gameObject.SetActive(false);
				HPText.gameObject.SetActive(false);
			}
	
	// Update is called once per frame
	void Update () {
		if (bossActive == true)
		{
			
			bossHP.maxValue = currentBoss.GetComponent<enemyHealth>().GetMaxHealth();
			bossHP.value = currentBoss.GetComponent<enemyHealth>().GetHealth();
			HPText.text = "" + currentBoss.GetComponent<enemyHealth>().GetHealth();
			if(currentBoss.GetComponent<enemyHealth>().GetHealth() < 1)
			{
				bossActive = false;
			}
			bossHP.gameObject.SetActive(true);
			HPText.gameObject.SetActive(true);
		}
		else
		{
			bossHP.gameObject.SetActive(false);
			HPText.gameObject.SetActive(false);
		}
	}
	public void SetUpBoss(GameObject boss)
	{
		currentBoss = boss;
		bossActive = true;
		
		
	}
}

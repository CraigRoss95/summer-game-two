using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class playerHealth : MonoBehaviour {
public int maxHealth;
public int currHealth;
private bool invinsable;
public float iFrameTime;
public GameObject playerModel;
public Text HPText;
private bool visable;
private bool animated;

	// Use this for initialization
	void Start () {
		invinsable = false;
		currHealth = maxHealth;

	}
	
	// Update is called once per frame
	void Update () 
	{
		HPText.text = "HP: " + currHealth.ToString();
		if (currHealth <= 0)
		{
			gameObject.transform.parent.gameObject.SetActive(false);
			gameObject.transform.parent.transform.parent.GetComponent<moveScreen>().Stop();
			SceneManager.LoadScene("startScreen");
		}	
	}
	public void TakeDamage(int damage)
	{
			
			currHealth = currHealth - damage;
			invinsable = true;
			Flash();
			Invoke("RemoveIFrames", iFrameTime);
	}

	void Flash()
	{
		if (invinsable == true)
		{
			if(visable == false)
			{
				playerModel.SetActive(true);
				visable = true;
				Invoke("Flash", 0.2f);
				//Debug.Log("Fric");
			}
			else
			{
				playerModel.SetActive(false);
				visable = false;
				Invoke("Flash", 0.2f);
				//Debug.Log("hec");
			}
		}
		
		else
		{
			playerModel.SetActive(true);
				visable = true;
		}
	}

	public bool GetInvinsable()
	{
		return invinsable;
	}
	void RemoveIFrames()
	{
		invinsable = false;
	}
}

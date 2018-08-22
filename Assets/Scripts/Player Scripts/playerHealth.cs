using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class playerHealth : MonoBehaviour {
public int maxHealth;
public int currHealth;
private bool invinsable;
public float iFrameTime;
	// Use this for initialization
	void Start () {
		invinsable = false;
		currHealth = maxHealth;
	}
	
	// Update is called once per frame
	void Update () 
	{
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
			Invoke("RemoveIFrames", iFrameTime);
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

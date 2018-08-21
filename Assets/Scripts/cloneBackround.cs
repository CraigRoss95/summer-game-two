using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cloneBackround : MonoBehaviour {

	public GameObject plane;
	public float delay;
	public float offsetDistance;
	public GameObject[] pannles;
	public GameObject movingScreen;
	private int activePannles;
	private int pannleNo;



	// Use this for initialization
	void Start () {
		activePannles = 1;
		pannleNo = 0;
		for(int i = 1; i < pannles.Length; i++)
		{
			pannles[i] = Instantiate(pannles[0]);
			pannles[i].transform.SetParent(gameObject.transform, false);
		}
	}
	
	// Update is called once per frame
	void Update () {
		if(activePannles < pannles.Length )
		{
			pannleNo++;
			activePannles++;
			pannles[pannleNo % pannles.Length].transform.Translate(Vector3.left * offsetDistance * pannleNo);



			
		}
		for(int i = 0; i < pannles.Length; i++)
		{
			if(pannles[i].transform.position.x - movingScreen.transform.position.x < -500)
			{
				pannles[i].transform.Translate(Vector3.left * offsetDistance * pannles.Length);
			}
		}

		
	}

}

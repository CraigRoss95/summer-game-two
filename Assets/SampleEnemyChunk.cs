using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SampleEnemyChunk : MonoBehaviour {

	public GameObject[] allChunks;
	public int chunkNumber;
	// Use this for initialization
	void Start () {
		int rand = Random.Range(0,allChunks.Length);
		for(int i = 0; i < allChunks.Length; i++)
		{
			if(i == rand){
				allChunks[i].SetActive(true);
			}
			else{
				allChunks[i].SetActive(false);
			}
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}

}

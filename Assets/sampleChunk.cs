using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sampleChunk : MonoBehaviour {

	public GameObject[] allChunks;
	public int chunkNumber;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void SetChunk(int chunkNo)
	{
		chunkNumber = chunkNo;
		for(int i = 0; i < allChunks.Length; i++)
		{
			if (i == chunkNo)
			{
				allChunks[i].SetActive(true);
			}
			else
			{
				allChunks[i].SetActive(false);
			}
		}
	}
	public float GetActiveChunkLenght()
	{
		return allChunks[chunkNumber].GetComponent<chunk>().GetChunkLength();
	}
	public int GetNumberOfTiles()
	{
		return allChunks.Length;
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class generateTerrain : MonoBehaviour {
public GameObject[] chunks;
public int nextChunkIndex;
public int endChunkIndex;
public float activeOffsetDistance;
private GameObject movingScreen;
private float chunksLenght;
	// Use this for initialization
	void Start () {
		movingScreen = GameObject.Find("moving screen");
		chunks[0].GetComponent<sampleChunk>().SetChunk(0);
		nextChunkIndex = 0;
		endChunkIndex = chunks.Length - 1;
		activeOffsetDistance = 0.0f;
		for (int i = 1; i < chunks.Length; i++)
		{
			chunks[i] = Instantiate(chunks[0],chunks[0].transform.parent);
		}
		for (int i = 1; i < chunks.Length; i++)
		{
			
			chunks[i].GetComponent<sampleChunk>().SetChunk(Random.Range(0, chunks[0].GetComponent<sampleChunk>().GetNumberOfTiles()));
			activeOffsetDistance = activeOffsetDistance + (chunks[i - 1].GetComponent<sampleChunk>().GetActiveChunkLenght() + chunks[i].GetComponent<sampleChunk>().GetActiveChunkLenght())/2;
			chunks[i].transform.Translate(Vector3.right * activeOffsetDistance);
		}
	}
	
	// Update is called once per frame
	void Update () 
	{
		NextChunk();
	}

	void NextChunk()
	{
		


		if(chunks[nextChunkIndex].transform.position.x - movingScreen.transform.position.x < -50)
		{	Debug.Log(" "+ nextChunkIndex);
			float otherLenght = 0;
		for(int i = 0; i < chunks.Length; i++)
		{
			if(i != nextChunkIndex)
			
			{
				otherLenght = otherLenght + chunks[i].GetComponent<sampleChunk>().GetActiveChunkLenght();
			}
			else{
				otherLenght = otherLenght + (chunks[i].GetComponent<sampleChunk>().GetActiveChunkLenght()/ 2.0f);
			}
		}
			
			//Debug.Log("delete chunk");
			chunks[nextChunkIndex].GetComponent<sampleChunk>().SetChunk(Random.Range(0, chunks[0].GetComponent<sampleChunk>().GetNumberOfTiles()));
			otherLenght = otherLenght + (chunks[nextChunkIndex].GetComponent<sampleChunk>().GetActiveChunkLenght()/ 2.0f);
			chunks[nextChunkIndex].transform.Translate(Vector3.right * otherLenght);
			
			nextChunkIndex = (nextChunkIndex + 1) % chunks.Length;
			endChunkIndex = (endChunkIndex + 1) % chunks.Length;
			
			
		}

	}
	

}
	//  + Vector3.Distance(chunk.GetComponent<chunk>().GetEnd().transform.position,chunk.GetComponent<chunk>().GetStart().transform.position));
	 
	// float distance = Vector3.Distance(chunk.GetComponent<chunk>().GetEnd().transform.position,chunk.GetComponent<chunk>().GetStart().transform.position);
	 //testChunk = Instantiate(chunk, chunk.transform.position + new Vector3(2 * distance,0,0), chunk.transform.rotation);
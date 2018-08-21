using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class generateTerrain : MonoBehaviour {
public GameObject[] chunks;
public int backChunkIndex;
public float activeOffsetDistance;
	// Use this for initialization
	void Start () {
		chunks[0].GetComponent<sampleChunk>().SetChunk(0);
		backChunkIndex = 0;
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
	void Update () {
		
	}
	

}
	//  + Vector3.Distance(chunk.GetComponent<chunk>().GetEnd().transform.position,chunk.GetComponent<chunk>().GetStart().transform.position));
	 
	// float distance = Vector3.Distance(chunk.GetComponent<chunk>().GetEnd().transform.position,chunk.GetComponent<chunk>().GetStart().transform.position);
	 //testChunk = Instantiate(chunk, chunk.transform.position + new Vector3(2 * distance,0,0), chunk.transform.rotation);
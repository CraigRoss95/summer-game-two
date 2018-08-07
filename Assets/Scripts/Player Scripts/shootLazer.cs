using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shootLazer : MonoBehaviour {

	public GameObject screen;
	public GameObject emitter;
	public float cooldownTime;
	private bool onCooldown;
	private GameObject clone;
	private RaycastHit hit;
	public GameObject cam;
	public GameObject targeter;
	public GameObject targeterTwo;
	public Canvas myCanvas;
	private Vector2 pos;
	public LayerMask screenLayerMask;
	private Vector3 cursor;
	private RaycastHit lazerHit;
	public GameObject lazer;
	public LayerMask shootLayer;
	public int damage;
	public int acuracyDebuff;



	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			if(Physics.Raycast(ray, out hit, 100, screenLayerMask))
		{
			Debug.DrawLine(cam.transform.position,hit.point);
			cursor = new Vector3 (hit.point.x,hit.point.y,0);
			RectTransformUtility.ScreenPointToLocalPointInRectangle(myCanvas.transform as RectTransform, Input.mousePosition, myCanvas.worldCamera, out pos);
			targeter.transform.position = myCanvas.transform.TransformPoint(pos);
			targeterTwo.transform.position = myCanvas.transform.TransformPoint(pos);
			
			if(hit.transform.tag == "enemy")
			{
				targeter.SetActive(false);
				targeterTwo.SetActive(true);
				Debug.Log("enemy? =  true");
			}
			else
			{
				targeter.SetActive(true);
				targeterTwo.SetActive(false);
				Debug.Log("enemy? =  false");
			}

		}
		transform.LookAt(cursor);
		
		if(onCooldown == false && Input.GetButton("Fire1"))
		{	float rand = Random.Range((-1 * acuracyDebuff), acuracyDebuff)/ 100.0f;
			Debug.Log("rand = " + rand);
			//rand = 0;
			if (Physics.Raycast(emitter.transform.position,emitter.transform.forward + new Vector3 (0,rand,0),out lazerHit,100,shootLayer))
			{
				Debug.DrawLine(emitter.transform.position, lazerHit.point, Color.red);
				clone = Instantiate(lazer);
				clone.GetComponent<LineRenderer>().SetPosition(0, emitter.transform.position);
				clone.GetComponent<LineRenderer>().SetPosition(1, lazerHit.point);

				if(lazerHit.transform.gameObject.tag == "enemy")
				{
					lazerHit.transform.gameObject.GetComponent<enemyHealth>().TakeDamage(damage);
				}
				
			}
			else
			{
			clone = Instantiate(lazer);
			clone.GetComponent<LineRenderer>().SetPosition(0, emitter.transform.position);
			clone.GetComponent<LineRenderer>().SetPosition(1, emitter.transform.position + (transform.forward + new Vector3 (0,rand,0)) * 100);
			}
			//clone.transform.parent = screen.transform;
			onCooldown = true;
			Invoke("PutOffCoolDown", cooldownTime);
		}
		
	}
	void PutOffCoolDown()
	{
		onCooldown = false;
	}
}


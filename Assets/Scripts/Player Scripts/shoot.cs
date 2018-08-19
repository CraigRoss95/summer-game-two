using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shoot : MonoBehaviour {

	public GameObject screen;
	public GameObject projectile;
	public GameObject emitter;
	public float cooldownTime;
	public float speed;
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
	public float acuracyDebuff;

	



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
				//Debug.Log("enemy? =  true");
			}
			else
			{
				targeter.SetActive(true);
				targeterTwo.SetActive(false);
				//Debug.Log("enemy? =  false");
			}

		//Debug.Log("log " + 	Vector3.Distance(hit.point, transform.position));
		}
		transform.LookAt(cursor);
		transform.eulerAngles = new Vector3 (transform.eulerAngles.x,transform.eulerAngles.y,0);
		if(onCooldown == false && Input.GetButton("Fire1"))
		{
			float rand = Random.Range((-1 * acuracyDebuff), acuracyDebuff)/ 100.0f;
			clone = Instantiate(projectile, emitter.transform.position + new Vector3(0,rand,0), emitter.transform.rotation);
			clone.GetComponent<Rigidbody>().AddForce((transform.forward * speed));
			clone.transform.parent = screen.transform;
			onCooldown = true;
			Invoke("PutOffCoolDown", cooldownTime);
		}
		
	}
	void PutOffCoolDown()
	{
		onCooldown = false;
	}
}

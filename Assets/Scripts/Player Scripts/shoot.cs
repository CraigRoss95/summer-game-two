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
	public AudioSource audioSource;
	public AudioClip[] shootSounds;
	public float rotationSpeed;
	private float currentCursorRotation;


	



	// Use this for initialization
	void Start () {
		currentCursorRotation = 0;

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
			{	targeter.transform.Rotate(Vector3.forward * rotationSpeed * 2);
				targeterTwo.transform.Rotate(Vector3.forward * rotationSpeed * 2);
				targeter.SetActive(false);
				targeterTwo.SetActive(true);
				//Debug.Log("enemy? =  true");
			}
			else
			{
				targeterTwo.transform.Rotate(Vector3.forward * rotationSpeed);
				targeter.transform.Rotate(Vector3.forward * rotationSpeed);
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
			audioSource.PlayOneShot(shootSounds[Random.Range(0, shootSounds.Length)], 2.0f);
			float rand = Random.Range((-1 * acuracyDebuff), acuracyDebuff)/ 100.0f;
			clone = Instantiate(projectile, emitter.transform.position + transform.up*rand, emitter.transform.rotation);
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

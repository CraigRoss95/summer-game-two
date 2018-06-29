 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerControler : MonoBehaviour {
	
	public Transform screenOffset;
	public float velocity;
	public float minAndMaxX;
	public float minAndMaxY;
	private Vector2 input;
	public Transform cam;
	private RaycastHit hit;
	public LayerMask screen;
	private Vector3 cursor;
	private bool isGrounded;
	public float height;
	public GameObject targeter;

	

	void Start()
	{
		isGrounded = false;
	}
	
	void LateUpdate()
	{	
		FindIsGrounded();
		GetInput();
		Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		if(Physics.Raycast(ray, out hit, 100, screen))
		{
			Debug.DrawLine(cam.transform.position,hit.point);
			cursor = hit.point;
			targeter.transform.position = hit.point;

		}
		

		Move();
	
		transform.LookAt(cursor);


	}
	void FindIsGrounded()
	{
		if(Physics.Raycast(gameObject.transform.position,Vector3.down,out hit,height/2.0f + 0.1f))
		{
			if (hit.transform.tag == "ground")
			{
				isGrounded = true;
			}
		}
		else
		{
			isGrounded = false;
		}
		Debug.Log("is grounded = " + isGrounded);
	}
	//sets input for every update
	void GetInput()
	{
		input.x = Input.GetAxisRaw("Horizontal");
		input.y = Input.GetAxisRaw("Vertical");
	}

	// get the direction the player is going in relation to the camera
	
	// moves the charicter forward
	void Move()
	{
		if((transform.position.x - screenOffset.position.x >= -minAndMaxX || input.x > 0) && (transform.position.x - screenOffset.position.x <= minAndMaxX || input.x < 0))
		{
			transform.position = transform.position + (new Vector3(input.x,0,0) * velocity * Time.deltaTime);
		}
		if(((transform.position.y >= -minAndMaxY  && isGrounded == false) || input.y > 0) && (transform.position.y <= minAndMaxY || input.y < 0))
		{
			transform.position = transform.position + (new Vector3(0,input.y,0) * velocity * Time.deltaTime);
		}
		
	}
	// finds which way is forward
}

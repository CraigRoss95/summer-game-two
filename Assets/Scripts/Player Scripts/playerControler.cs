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
	public GameObject targeterTwo;
	private Vector2 pos;
	public Canvas myCanvas;
	public float speedUpFactor;
	public float SlowDownFactor;
	public float maxSpeed;
	public float minSpeed;
	public bool diagonal;

	

	void Start()
	{
		isGrounded = false;
	}
	
	void LateUpdate()
	{	
		FindIsGrounded();
		GetInput();

		

		Move();
	


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
		if((transform.localPosition.x >= -minAndMaxX || input.x > 0) && (transform.localPosition.x <= minAndMaxX || input.x < 0))
		{
			transform.localPosition = transform.localPosition + (new Vector3(input.x,0,0) * velocity * Time.deltaTime);
		}
		if(((transform.localPosition.y >= -minAndMaxY   && isGrounded == false) || input.y > 0) && (transform.localPosition.y <= minAndMaxY || input.y < 0))
		{
			transform.localPosition = transform.localPosition + (new Vector3(0,input.y,0) * velocity * Time.deltaTime);
		}

		
		velocity = Mathf.Clamp(velocity,minSpeed,maxSpeed);
		if(input.x != 0 && input.y != 0 && diagonal == false)
		{
			diagonal = true;

		}
		else 
		{
			diagonal = false;
		}
		Debug.Log("velocity = " + velocity);
		
	}
	// finds which way is forward
}

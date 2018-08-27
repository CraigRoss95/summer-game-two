 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerControler : MonoBehaviour {
	public GameObject bottemPlate;
	public Transform screenOffset;
	public float velocity;
	public float minAndMaxX;
	public float minAndMaxY;
	private Vector2 input;
	public Transform cam;
	private RaycastHit hit;
	public LayerMask screen;
	public LayerMask ground;
	private Vector3 cursor;
	private bool isGrounded;
	public float height;
	private Vector2 pos;
	public Canvas myCanvas;
	public float speedUpFactor;
	public float SlowDownFactor;
	public float maxSpeed;
	public float minSpeed;
	public bool diagonal;

	private bool flying;
	private float dodgeMoveSpeed;
	public float dodgeMoveSpeedFactor;
	private float originalVelocity;
	public GameObject hitBox;
	private Vector2 rawInput;
	private bool jumping;
	public float extraGravity;
	public float jumpingFource;
	public float maxJumpTime;
	private float currentJumpTime;
	

	void DodgeSpeed()
	{
		if(hitBox.GetComponent<dodge>().GetIsDodgeing() == true)
		{
			velocity = dodgeMoveSpeed;
			if (rawInput == new Vector2(0,0))
			{
				input = new Vector2(1,0);
			}
		}
		else
		{
			velocity = originalVelocity;
		}	
	}

	void DodgyMovement()
	{
		if (hitBox.GetComponent<dodge>().GetIsDodgeing() == false)
		{
			input = rawInput;
		}
	}
	void Start()
	{
		jumping = false;
		dodgeMoveSpeed = velocity * dodgeMoveSpeedFactor;
		originalVelocity = velocity;
		isGrounded = false;
		flying = true;
	}
	
	void Update()
	{
		DodgyMovement();
		DodgeSpeed();
		FindIsGrounded();
		GetInput();
		Jump();
		Debug.Log("flying = " + flying);
		if (flying == false && isGrounded == false)
		{
			gameObject.GetComponent<Rigidbody>().useGravity = true;
		}
		if (flying == true)
		{
			MoveFlying();
		}
		else{
			MoveRunning();
		}
		ExtraGravity();
	}

	public bool GetIsGrounded()
	{
		return isGrounded;
	}
	void FindIsGrounded()
	{
		if(bottemPlate.GetComponent<touchingGround>().GetTouching() == true && flying == false)
		{
			isGrounded = true;
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
		rawInput.x = Input.GetAxisRaw("Horizontal");
		rawInput.y = Input.GetAxisRaw("Vertical");
	}


	// get the direction the player is going in relation to the camera
	
	// moves the charicter forward
	void MoveFlying()
	{
		gameObject.GetComponent<Rigidbody>().useGravity = false;
		if((transform.localPosition.x >= -minAndMaxX || input.x > 0) && (transform.localPosition.x <= minAndMaxX || input.x < 0))
		{
				transform.localPosition = transform.localPosition + (new Vector3(input.x,0,0) * velocity * Time.deltaTime);	
		}
		if(((transform.localPosition.y >= -minAndMaxY   && isGrounded == false) || input.y > 0) && (transform.localPosition.y <= minAndMaxY || input.y < 0))
		{
			transform.localPosition = transform.localPosition + (new Vector3(0,input.y,0) * velocity * Time.deltaTime);
		}
		if (flying == true && Input.GetButtonDown("jump"))
		{
			flying = false;
		} 
	//	Debug.Log("velocity = " + velocity);
		
	}
	void MoveRunning()
	{
		if((transform.localPosition.x >= -minAndMaxX || input.x > 0) && (transform.localPosition.x <= minAndMaxX || input.x < 0))
		{
				transform.localPosition = transform.localPosition + (new Vector3(input.x,0,0) * velocity * Time.deltaTime);	
		}
		if (jumping == false)
		{
			gameObject.GetComponent<Rigidbody>().useGravity = true;
		}
		if(flying == false && Input.GetButtonDown("Vertical"))
		{
			gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
			gameObject.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
			flying = true;
		}
	}
	// finds which way is forward
	public bool GetFlying()
	{
		return flying;
	}
	void Jump()
	{
		if (isGrounded == true && flying == false && Input.GetButtonDown("jump"))
		{
			currentJumpTime = 0;
			jumping = true;
		}

		if (jumping == true && Input.GetButton("jump") && currentJumpTime < maxJumpTime)
		{
			
			Debug.Log("Frick");
			currentJumpTime = currentJumpTime + Time.deltaTime;
			gameObject.GetComponent<Rigidbody>().useGravity = false;
			gameObject.transform.Translate(Vector3.up * Time.deltaTime* jumpingFource);
		}
		else
		{
			gameObject.GetComponent<Rigidbody>().useGravity = true;
			jumping = false;
		}
	}
	void ExtraGravity()
	{
		if (gameObject.GetComponent<Rigidbody>().useGravity == true)
		{
			gameObject.GetComponent<Rigidbody>().AddForce(Vector3.down* extraGravity);
		}
	}
	
}

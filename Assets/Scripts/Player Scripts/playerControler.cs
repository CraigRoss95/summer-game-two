 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerControler : MonoBehaviour {
	public GameObject bottemPlate;
	public Animator playerAnimations;
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
	public GameObject targeter;
	public GameObject targeterTwo;
	private Vector2 pos;
	public Canvas myCanvas;
	public float speedUpFactor;
	public float SlowDownFactor;
	public float maxSpeed;
	public float minSpeed;
	public bool diagonal;
	private bool jumping;
	private bool falling;
	public float jumpingTime;
	public float jumpSpeed;
	private float tempJumpSpeed;
	public float jumpingDecayRate;
	private bool flying;
	public GameObject frontPlate;
	public GameObject backPlate;
	public GameObject topPlate;
	private float dodgeMoveSpeed;
	public float dodgeMoveSpeedFactor;
	private float originalVelocity;
	public GameObject hitBox;
	private Vector2 rawInput;
	

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

	void Start()
	{
		
		dodgeMoveSpeed = velocity * dodgeMoveSpeedFactor;
		originalVelocity = velocity;
		isGrounded = false;
		jumping = false;
		falling = false;
		tempJumpSpeed = 0;
		falling = true;
		flying = false;
	}
	
	void Update()
	{
		DodgyMovement();
		DodgeSpeed();
		FindIsGrounded();
		GetInput();
		Jump();
		Move();
		StartFlight();
		Push();
	}
	public bool GetIsGrounded()
	{
		return isGrounded;
	}
	void FindIsGrounded()
	{
		if(bottemPlate.GetComponent<touchingGround>().GetTouching() == true)
		{
			tempJumpSpeed = 5.0f;
	
			flying = false;	
			isGrounded = true;
			CancelInvoke("SetFalling");
			playerAnimations.Play("running");
		}
		else
		{
			if(jumping == false && falling == false)
			{
				playerAnimations.Play("floating");
			}
			if(flying == false)
			{
				falling = true;
			}
			
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
	void DodgyMovement()
	{
		if (hitBox.GetComponent<dodge>().GetIsDodgeing() == false)
		{
			input = rawInput;
		}
	}

	// get the direction the player is going in relation to the camera
	
	// moves the charicter forward
	void Move()
	{
		if((transform.localPosition.x >= -minAndMaxX || input.x > 0) && (transform.localPosition.x <= minAndMaxX || input.x < 0))
		{
			if (frontPlate.GetComponent<touchingGround>().GetTouching() == false && backPlate.GetComponent<touchingGround>().GetTouching() == false)
			{
				transform.localPosition = transform.localPosition + (new Vector3(input.x,0,0) * velocity * Time.deltaTime);
			}
			
		}
		if(((transform.localPosition.y >= -minAndMaxY   && isGrounded == false) || input.y > 0) && (transform.localPosition.y <= minAndMaxY || input.y < 0))
		{
			transform.localPosition = transform.localPosition + (new Vector3(0,input.y,0) * velocity * Time.deltaTime);
		}

		
		
		if(input.x != 0 && input.y != 0 && diagonal == false)
		{
			diagonal = true;

		}
		else 
		{
			diagonal = false;
		}
	//	Debug.Log("velocity = " + velocity);
		
	}
	// finds which way is forward
	void Jump()
	{
		if (Input.GetButtonDown("jump") && flying == true)
		{
			flying = false;
			jumpSpeed = 5.0f;
		}
		//Debug.Log ("tempjumpspeed = " + tempJumpSpeed);
		if(Input.GetButtonDown("jump") && isGrounded == true)
		{	
			
			tempJumpSpeed = jumpSpeed;
		//	Debug.Log("you jumped");
			jumping = true;
			Invoke("SetFalling", jumpingTime);
			
		}
		if (jumping == true)
		{
			if (Input.GetButton("jump"))
			{ 
			transform.localPosition = transform.localPosition + (new Vector3(0,1.0f,0) * tempJumpSpeed * Time.deltaTime);
			tempJumpSpeed = tempJumpSpeed - Time.deltaTime * jumpingDecayRate;
			tempJumpSpeed = Mathf.Clamp(tempJumpSpeed,0,jumpSpeed);
			}
			else
			{
				if (jumping == true)
				{
					tempJumpSpeed = 5.0f;
					jumping = false;
					falling = true;	
				}
				
			}
		}
		if (falling == true && flying == false && jumping == false)
		{
			if(isGrounded == false)
			{
			transform.localPosition = transform.localPosition + (new Vector3(0,-1.0f,0) * tempJumpSpeed * Time.deltaTime);
			tempJumpSpeed = tempJumpSpeed + Time.deltaTime * jumpingDecayRate;
			tempJumpSpeed = Mathf.Clamp(tempJumpSpeed,0,jumpSpeed);
			}
			else
			{
				falling = false;
			}
		}
		

	}

	void SetFalling()
	{
		jumping = false;
		falling = true;
		tempJumpSpeed = 5.0f;
	}
	
	void StartFlight()
	{
		if (Input.GetAxisRaw("Vertical") != 0 )
		{
			flying = true;
			falling = false;
			jumping = false;
			CancelInvoke("SetFalling");
		}
		
	}
	public bool notFlying()
	{
		if (jumping == true || falling == true)
		{
			return true;
		}
		else
		{
			return false;
		}
	}
	void Push()
	{
		if (Physics.Raycast(gameObject.transform.position,Vector3.down,out hit,height/2.0f + 0.1f, ground))
			{
				if(hit.distance < height/2.0f)
					{
						falling = false;
						gameObject.transform.Translate(Vector3.up * 0.1f);
					}
			}
		if ( frontPlate.GetComponent<touchingGround>().GetTouching() == true)
		{
			gameObject.transform.Translate(Vector3.left* 0.2f);
		}
		if ( backPlate.GetComponent<touchingGround>().GetTouching() == true)
		{
			gameObject.transform.Translate(Vector3.right* 0.2f);
		}
		if ( topPlate.GetComponent<touchingGround>().GetTouching() == true)
		{
			gameObject.transform.Translate(Vector3.down* 0.2f);
		}
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

	public CharacterController2D controller;
	public Animator animator;

	public float runSpeed = 40f;

	float horizontalMove = 0f;
	bool jump = false;
	bool dash = false;

	public bool isNear = true;
	public bool isFar = false;
	public bool isEnd = false;

	private float time = 0f;
	private float startTime = 2f;

	//bool dashAxis = false;
	
	// Update is called once per frame
	void Update () {

		time += 1f * Time.deltaTime;

		if (time < startTime)
		{
			time += 1f * Time.deltaTime;
		}
		else
		{
			horizontalMove = runSpeed;
		}

		animator.SetFloat("Speed", Mathf.Abs(horizontalMove));

		if (Input.GetKeyDown(KeyCode.Space) && isNear && !isEnd)
		{
			animator.SetBool("isShrink", true);
			controller.nearJump = true;
			jump = true;
		}
		if (Input.GetKeyDown(KeyCode.Space) && isFar && !isEnd)
		{
			animator.SetBool("isShrink", false);
			controller.farJump = true;
			jump = true;
		}

		/*if (Input.GetKeyDown(KeyCode.V))
		{
			dash = true;
		}*/


		/*if (Input.GetAxisRaw("Dash") == 1 || Input.GetAxisRaw("Dash") == -1) //RT in Unity 2017 = -1, RT in Unity 2019 = 1
		{
			if (dashAxis == false)
			{
				dashAxis = true;
				dash = true;
			}
		}
		else
		{
			dashAxis = false;
		}
		*/

	}

	public void OnFall()
	{
		animator.SetBool("IsJumping", true);
	}

	public void OnLanding()
	{
		animator.SetBool("IsJumping", false);
	}

	void FixedUpdate ()
	{
		// Move our character
		controller.Move(horizontalMove * Time.fixedDeltaTime, jump, dash);
		jump = false;
		dash = false;
	}
}

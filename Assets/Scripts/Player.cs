using System;
using System.Collections;
using System.Collections.Generic;

using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Player : MonoBehaviour
{
	[SerializeField]
	private float walkingSpeed = 2f;

	[SerializeField]
	private float runningSpeed = 3f;

	private Rigidbody2D rigidbody;

	private void Start()
	{
		rigidbody = GetComponent<Rigidbody2D>();
	}

	private void FixedUpdate()
	{
		Move();
	}
	
	
	
	private void Move()
	{
		var walkingDirection = Vector3.zero;

		walkingDirection += Vector3.up * Input.GetAxis("Vertical");
		walkingDirection += Vector3.right * Input.GetAxis("Horizontal");

		walkingDirection = walkingDirection.normalized;
		walkingDirection *= Input.GetKey(KeyCode.LeftShift) ? runningSpeed : walkingSpeed;

		rigidbody.MovePosition(transform.position + walkingDirection * Time.fixedDeltaTime);
	}
}

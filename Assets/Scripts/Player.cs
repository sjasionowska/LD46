﻿using System;
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

	private Animator animator;

#pragma warning disable 108,114
	// ReSharper disable once IdentifierTypo
	private Rigidbody2D rigidbody;
#pragma warning restore 108,114

	private Vector2 movement;

	private float currentSpeed;

	private static readonly int Horizontal = Animator.StringToHash("Horizontal");

	private static readonly int Vertical = Animator.StringToHash("Vertical");

	private static readonly int Speed = Animator.StringToHash("Speed");

	private void Start()
	{
		rigidbody = GetComponent<Rigidbody2D>();
		animator = GetComponent<Animator>();
	}

	private void Update()
	{
		movement.x = Input.GetAxisRaw("Horizontal");
		movement.y = Input.GetAxisRaw("Vertical");
		currentSpeed = Input.GetKey(KeyCode.LeftShift) ? runningSpeed : walkingSpeed;
		
		animator.SetFloat(Horizontal, movement.x);
		animator.SetFloat(Vertical, movement.y);
		animator.SetFloat(Speed, movement.sqrMagnitude);
	}

	private void FixedUpdate()
	{
		rigidbody.MovePosition(rigidbody.position + movement * (currentSpeed * Time.fixedDeltaTime));
	}

	// private void Move()
	// {
	// 	var walkingDirection = Vector3.zero;
	//
	// 	walkingDirection += Vector3.up * Input.GetAxis("Vertical");
	// 	walkingDirection += Vector3.right * Input.GetAxis("Horizontal");
	//
	// 	walkingDirection = walkingDirection.normalized;
	// 	walkingDirection *= Input.GetKey(KeyCode.LeftShift) ? runningSpeed : walkingSpeed;
	//
	// 	rigidbody.MovePosition(transform.position + walkingDirection * Time.fixedDeltaTime);
	// }
}

using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;

using UnityEngine;

using Vector2 = UnityEngine.Vector2;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Entity))]
[RequireComponent(typeof(PlayerShooting))]
[RequireComponent(typeof(Animator))]
public class Player : MonoBehaviour
{
	[SerializeField]
	private float walkingSpeed = 2f;

	[SerializeField]
	private float runningSpeed = 3f;

	private Animator animator;

	private Entity entity;

#pragma warning disable 108,114

	// ReSharper disable once IdentifierTypo
	private Rigidbody2D rigidbody;
#pragma warning restore 108,114

	private Vector2 movement;

	private float xDirection;

	private float yDirection;

	// TODO
	// private GameManager gameManager;

	public Vector2 Movement
	{
		get => movement;
	}

	public Vector2 Direction
	{
		get { return new Vector2(xDirection, yDirection); }
	}

	private float currentSpeed;

	private static readonly int Horizontal = Animator.StringToHash("Horizontal");

	private static readonly int Vertical = Animator.StringToHash("Vertical");

	private static readonly int Speed = Animator.StringToHash("Speed");

	private static readonly int XDirection = Animator.StringToHash("xDirection");

	private static readonly int YDirection = Animator.StringToHash("yDirection");

	private void Start()
	{
		rigidbody = GetComponent<Rigidbody2D>();
		animator = GetComponent<Animator>();
		entity = GetComponent<Entity>();
		
		// TODO enable
		// gameManager = FindObjectOfType<GameManager>();
	}

	private void Update()
	{
		movement.x = Input.GetAxisRaw("Horizontal");
		movement.y = Input.GetAxisRaw("Vertical");
		currentSpeed = Input.GetKey(KeyCode.LeftShift) ? runningSpeed : walkingSpeed;

		var movementNormalized = movement;

		animator.speed = currentSpeed / 3;
		animator.SetFloat(Horizontal, movementNormalized.x);
		animator.SetFloat(Vertical, movementNormalized.y);

		animator.SetFloat(Speed, movement.sqrMagnitude);
	}

	private void FixedUpdate()
	{
		rigidbody.MovePosition(rigidbody.position + movement * (currentSpeed * Time.fixedDeltaTime));

		if (Math.Abs(movement.magnitude) > 0.5)
		{
			xDirection = animator.GetFloat(Horizontal);
			yDirection = animator.GetFloat(Vertical);

			animator.SetFloat(XDirection, xDirection);
			animator.SetFloat(YDirection, yDirection);
		}
	}

	private void OnCollisionEnter2D(Collision2D other)
	{
		if (other.gameObject.CompareTag("ScreamBullet"))
		{
			entity.GetHurt();
		}
	}
	
	private void OnCollisionStay2D(Collision2D other)
	{
		
		
		if(other.gameObject.CompareTag("CoffeeShop"))
		{
			
			if (Input.GetKeyDown(KeyCode.E))
			{
				// TODO: enable gameManager!!!
				// if (gameManager.GameWon)
				// {
				// 	WinGame();
				// }
			}

		}
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

using System;
using System.Collections;
using System.Collections.Generic;

using UnityEngine;

using Random = UnityEngine.Random;

[RequireComponent(typeof(Rigidbody2D))]
public class Enemy : MonoBehaviour
{
	[SerializeField]
	private float speed = 1f;

	[SerializeField]
	private float attackDistance = 2f;

	[SerializeField]
	private float distanceNecessaryToAttack = 4f;

	[SerializeField]
	private GameObject screamBulletPrefab;

	private float attackDamage = 1f;

	private Vector2 targetPosition;

	private Vector2 direction;

	private bool movingIndependently;

#pragma warning disable 108,114

	// ReSharper disable once IdentifierTypo
	private Rigidbody2D rigidbody;
#pragma warning restore 108,114

	private GameObject targetPlayer;

	private AudioManager audioManager;

	private void Start()
	{
		rigidbody = GetComponent<Rigidbody2D>();

		targetPlayer = GameObject.FindGameObjectWithTag("Player");
		audioManager = FindObjectOfType<AudioManager>();

		StartCoroutine(ChangeTargetPositionCoroutine());
	}

	private IEnumerator ChangeTargetPositionCoroutine()
	{
		while (true)
		{
			targetPosition = (Vector2)transform.position + Random.insideUnitCircle * 2f;
			yield return new WaitForSeconds(1f);
		}
	}

	private void Update()
	{
		Attack();
	}

	private void FixedUpdate()
	{
		Move();
	}

	private void Move()
	{
		var position = rigidbody.position;

		// if the target is not null, count the distance between the target and the enemy
		// if the distance is less or equal to  distanceNecessaryToAttack field
		// start following the player
		if (targetPlayer != null)
		{
			var distance = ((Vector2)targetPlayer.transform.position - position).magnitude;
			if (distance <= distanceNecessaryToAttack)
			{
				targetPosition = targetPlayer.transform.position;
			}
		}

		direction = targetPosition - position;

		// different way of moving, not sure if this works and how
		// var targetVelocity = direction.normalized;
		// rigidbody.MovePosition(targetPosition * (speed * Time.fixedDeltaTime));

		rigidbody.MovePosition(position + direction * (speed * Time.fixedDeltaTime));
	}

	private void Attack()
	{
		if (targetPlayer == null) return;

		var distance = (targetPlayer.transform.position - transform.position).magnitude;

		if (distance > attackDistance)
		{
			StopAllCoroutines();
			StartCoroutine(ChangeTargetPositionCoroutine());
			
			return;
		}

		StartCoroutine(ShootScream());
	}

	private IEnumerator ShootScream()
	{
		while (true)
		{
			Vector3 shootingTarget;

			shootingTarget = Vector3.Normalize(targetPlayer.transform.position);

			var screamBullet = Instantiate(
				screamBulletPrefab,
				transform.position + new Vector3(shootingTarget.x, shootingTarget.y, 0),
				Quaternion.identity);
			screamBullet.transform.parent = transform;

			var screamBulletRigidbody = screamBullet.GetComponent<Rigidbody2D>();

			screamBulletRigidbody.AddForce(20 * shootingTarget);

			audioManager.Play("Scream1");
			yield return new WaitForSeconds(5f);
		}
	}

	private void OnCollisionEnter2D(Collision2D other)
	{
		if (other.gameObject.CompareTag("Bullet"))
		{
			Debug.Log("Bullet");
		}

		if (other.gameObject.CompareTag("Player"))
		{
			Debug.Log("Player");
		}
	}
}

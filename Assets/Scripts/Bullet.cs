using System;

using UnityEngine;

public class Bullet : MonoBehaviour
{
	private float Time = 0.5f;

	private void Start ()
	{
		Destroy(gameObject, Time);
	}

	private void OnCollisionEnter(Collision other)
	{
		Destroy(gameObject);
	}

	private void OnCollisionEnter2D(Collision2D other)
	{
		Destroy(gameObject);
	}
}

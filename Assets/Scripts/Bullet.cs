using System;

using UnityEngine;

public class Bullet : MonoBehaviour
{
	private float Time = 1f;

	private void Start ()
	{
		Destroy(gameObject, Time);
	}

	private void OnCollisionEnter(Collision other)
	{
		Destroy(gameObject);
	}
}

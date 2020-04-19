using System;
using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class LoveDrink : MonoBehaviour
{
	[SerializeField]
	private GameObject canvas;

	private void Start()
	{
		canvas.SetActive(false);
	}



	private void OnCollisionEnter2D(Collision2D other)
	{
		if (other.gameObject.CompareTag("Player"))
		{
			canvas.SetActive(true);
		}
	}

	private void OnCollisionExit2D(Collision2D other)
	{
		if (other.gameObject.CompareTag("Player"))
		{
			canvas.SetActive(false);
		}
	}
}

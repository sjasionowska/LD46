using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class CoffeeShopCollider : MonoBehaviour
{
	[SerializeField]
	private GameObject canvas;

	// private GameManager gameManager;
	private void Start()
	{
		canvas.SetActive(false);

		// gameManager = FindObjectOfType<GameManager>();
	}

	private void OnCollisionEnter2D(Collision2D other)
	{
		if (other.gameObject.CompareTag("Player"))
		{
			// TODO: enable gamemanagers!!!
			// if (gameManager.GameWon)
			// {
			// 	canvas.SetActive(true);
			// }
		}
	}

	private void OnCollisionExit2D(Collision2D other)
	{
		if (other.gameObject.CompareTag("Player"))
		{
			// if (gameManager.GameWon)
			// {
			// 	canvas.SetActive(true);
			// }
		}
	}
}

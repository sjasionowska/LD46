using System;
using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class Entity : MonoBehaviour
{
	[SerializeField]
	private int initialHealth = 5;

	public event Action<int> OnHealthChanged;

	public event Action OnKilled;

	private int health;

	private EnemySpawner parent;

	private bool thisIsEnemy;

	private GameManager gameManager;

	private GameObject canvas;

	private DeadMenu deadMenu;

	public int Health
	{
		get { return health; }

		set
		{
			health = value;

			if (health <= 0) health = 0;

			if (OnHealthChanged != null) OnHealthChanged.Invoke(health);

			if (health == 0)
			{
				if (gameObject.CompareTag("Player"))
				{
					Debug.Log("You've died. lol");
				}

				if (OnKilled != null) OnKilled.Invoke();

				if (thisIsEnemy)
				{
					parent.RemoveEnemy(this.gameObject);
					Destroy(gameObject);
				}

				else
				{
					deadMenu.ShowDeadMenu();
				}
			}
		}
	}

	private void Start()
	{
		gameManager = FindObjectOfType<GameManager>();
		canvas = GameObject.FindWithTag("Canvas");
		deadMenu = canvas.GetComponent<DeadMenu>();

		Health = initialHealth;
		thisIsEnemy = gameObject.CompareTag("Enemy");

		if (thisIsEnemy) parent = gameObject.transform.parent.gameObject.GetComponent<EnemySpawner>();
	}

	public void GetHurt()
	{
		Health--;
	}
}

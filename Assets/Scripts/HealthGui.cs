using System;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UI;

public class HealthGui : MonoBehaviour
{
	[SerializeField]
	private List<GameObject> peaces;

	[SerializeField]
	private Text bulletsCounter;

	[SerializeField]
	private Text eneniesCounter;

	private int currentHealth;

	private int bullets;

	private int enemies;

	private Entity entity;

	private PlayerShooting playerShooting;

	private EnemySpawner enemySpawner;

	void Awake()
	{
		playerShooting = FindObjectOfType<Player>().GetComponent<PlayerShooting>();
		entity = FindObjectOfType<Player>().GetComponent<Entity>();
		entity.OnHealthChanged += RefreshCurrentHealth;
		playerShooting.OnBulletsChanged += RefreshCurrentBullets;
		enemySpawner = FindObjectOfType<EnemySpawner>();
		enemies = enemySpawner.EnemiesCount;
		RefreshEnemies();

		enemySpawner.EnemiesCountChanged += RefreshCurrentEnemies;
	}

	private void RefreshCurrentEnemies(int currentEnemies)
	{
		enemies = currentEnemies;
		RefreshEnemies();
	}

	private void RefreshEnemies()
	{
		eneniesCounter.text = enemies.ToString();
	}

	private void Start()
	{
		foreach (var life in peaces)
		{
			life.GetComponent<Image>().color = Color.white;
		}
	}

	private void RefreshPeaces()
	{
		for (int i = 0; i < peaces.Count; i++)
		{
			// if (i < currentHealth) peaces[i].GetComponent<Image>().sprite = peaceImages[0];
			//
			// else peaces[i].GetComponent<Image>().sprite = peaceImages[1];		

			if (i < currentHealth) peaces[i].GetComponent<Image>().color = Color.white;

			else peaces[i].GetComponent<Image>().color = Color.gray;
		}
	}

	private void RefreshCurrentHealth(int health)
	{
		currentHealth = health;
		if (currentHealth > peaces.Count)
		{
			Debug.LogError("Current health is bigger than the amount of all hearts visible on the GUI.");
		}

		RefreshPeaces();
	}

	private void RefreshCurrentBullets(int curBullets)
	{
		bullets = curBullets;
		RefreshBullets();
	}

	private void RefreshBullets()
	{
		bulletsCounter.text = bullets.ToString();
	}
}

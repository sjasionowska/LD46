using System;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UI;

public class HealthGui : MonoBehaviour
{
	[SerializeField]
	private List<GameObject> lives;

	[SerializeField]
	private List<Sprite> heartImages;

	private int currentHealth;

	private Entity entity;

	void Awake()
	{
		entity = FindObjectOfType<Player>().GetComponent<Entity>();
		entity.OnHealthChanged += RefreshCurrentHealth;
	}

	private void Start()
	{
		foreach (var life in lives)
		{
			life.GetComponent<Image>().sprite = heartImages[0];
		}
	}

	private void RefreshHearts()
	{
		for (int i = 0; i < lives.Count; i++)
		{
			if (i < currentHealth) lives[i].GetComponent<Image>().sprite = heartImages[0];
			else lives[i].GetComponent<Image>().sprite = heartImages[1];
		}
	}

	private void RefreshCurrentHealth(int health)
	{
		currentHealth = health;
		if (currentHealth > lives.Count)
		{
			Debug.LogError("Current health is bigger than the amount of all hearts visible on the GUI.");
		}

		RefreshHearts();
	}
}

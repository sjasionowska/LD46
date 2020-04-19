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
				if(gameObject.CompareTag("Player"))
				{
					Debug.Log("You've died. lol");
				}
				
				if (OnKilled != null) OnKilled.Invoke();

				Destroy(gameObject);
			}
		}
	}

	public void GetHurt()
	{
		Health--;
		Debug.Log(Health);
	}

	private void Start()
	{
		Health = initialHealth;
	}
}

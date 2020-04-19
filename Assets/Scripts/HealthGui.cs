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
	
	private void Start()
	{
		foreach (var life in lives)
		{
			life.GetComponent<SpriteRenderer>().sprite = heartImages[0];
		}
	}

	void Awake()
	{
		// FindObjectOfType<Player>().GetComponent<Entity>().OnHealthChanged 
		                                                                   
	}
}

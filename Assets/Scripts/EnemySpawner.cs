using System;
using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
	[SerializeField]
	private GameObject enemyPrefab;

	[SerializeField]
	private int enemiesCount;

	[SerializeField]
	private List<Vector3> enemiesCoordinates;

	private List<GameObject> enemiesObjects;
	

	public event Action<int> EnemiesCountChanged;

	public event Action AllEnemiesDefeated;

	public int EnemiesCount
	{
		get { return enemiesCount; }
	}

	private void Start()
	{
		enemiesObjects = new List<GameObject>();

		for (int i = 0; i < enemiesCount; i++)
		{
			var enemy = Instantiate(enemyPrefab, transform.position + enemiesCoordinates[i], Quaternion.identity);
			enemy.transform.parent = transform;
			enemiesObjects.Add(enemy);
		}
	}

	public void RemoveEnemy(GameObject enemyToRemove)
	{
		enemiesObjects.Remove(enemyToRemove);
		enemiesCount--;
		if (EnemiesCountChanged != null) EnemiesCountChanged.Invoke(EnemiesCount);

		if (enemiesCount == 0)
		{
			if (AllEnemiesDefeated != null) AllEnemiesDefeated.Invoke();
		}
	}
}

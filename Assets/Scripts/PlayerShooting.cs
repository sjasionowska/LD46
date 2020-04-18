using System;

using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
	[SerializeField]
	private GameObject bulletPrefab;

	private Player player;

	void Update()
	{
		if (Input.GetKeyDown(KeyCode.Space)) ShootLove();
	}

	private void Start()
	{
		player = gameObject.GetComponent<Player>();
	}

	void ShootLove()
	{
		Debug.Log(player.Movement.x);
		Debug.Log(player.Movement.y);

		var heartBullet = Instantiate(
			bulletPrefab,
			transform.position + new Vector3(player.Movement.x, player.Movement.y, 0),
			Quaternion.identity);
		heartBullet.transform.parent = transform;

		var bulletRigidbody = heartBullet.GetComponent<Rigidbody2D>();

		bulletRigidbody.AddForce(20 * player.Movement);
	}
}

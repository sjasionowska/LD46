using System;

using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
	[SerializeField]
	private GameObject bulletPrefab;

	private Player player;

	private AudioManager audioManager;

	void Update()
	{
		if (Input.GetKeyDown(KeyCode.Space)) ShootLove();
	}

	private void Start()
	{
		player = gameObject.GetComponent<Player>();
		audioManager = FindObjectOfType<AudioManager>();
	}

	void ShootLove()
	{
		Vector3 shootingTarget;

		if (Math.Abs(player.Movement.magnitude) < 0.01) shootingTarget = 0.5f * Vector2.down;
		else shootingTarget = 0.5f * player.Movement;

		var heartBullet = Instantiate(
			bulletPrefab,
			transform.position + new Vector3(shootingTarget.x, shootingTarget.y, 0),
			Quaternion.identity);
		heartBullet.transform.parent = transform;

		var bulletRigidbody = heartBullet.GetComponent<Rigidbody2D>();

		bulletRigidbody.AddForce(20 * shootingTarget);

		audioManager.Play("LoveShot");
	}
}

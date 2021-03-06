using System;

using UnityEngine;
[RequireComponent(typeof(Player))]
public class PlayerShooting : MonoBehaviour
{
	[SerializeField]
	private GameObject bulletPrefab;

	public int Bullets
	{
		get { return bullets; }

		private set
		{
			bullets = value;

			if (OnBulletsChanged != null) OnBulletsChanged.Invoke(bullets);
		}
	}

	public event Action<int> OnBulletsChanged;

	private int bullets;

	private Player player;

	private AudioManager audioManager;

	void Update()
	{
		if (Input.GetKeyDown(KeyCode.Space)) ShootLove();
	}

	private void Start()
	{
		Bullets = 10;
		player = gameObject.GetComponent<Player>();
		audioManager = FindObjectOfType<AudioManager>();
	}

	void ShootLove()
	{
		if (Bullets == 0) return;

		Vector3 shootingTarget;

		// if (Math.Abs(player.Movement.magnitude) < 0.01)
		// {
		// 	shootingTarget = 0.5f * player.Direction;
		// 	// shootingTarget = 0.5f * Vector2.down;
		// }
		// else shootingTarget = 0.5f * player.Movement;

		shootingTarget = player.Direction.normalized;

		var heartBullet = Instantiate(
			bulletPrefab,
			transform.position + new Vector3(shootingTarget.x, shootingTarget.y, 0),
			Quaternion.identity);
		heartBullet.transform.parent = transform;

		var bulletRigidbody = heartBullet.GetComponent<Rigidbody2D>();

		bulletRigidbody.AddForce(15 * shootingTarget);

		Bullets--;

		audioManager.Play("LoveShot");
	}

	public void CollectBullets()
	{
		Bullets = 10;
	}

	private void OnCollisionStay2D(Collision2D other)
	{
		if (other.gameObject.CompareTag("LoveDrink"))
		{
			if(Input.GetKeyDown(KeyCode.E))
				CollectBullets();
		}
		

	}

}

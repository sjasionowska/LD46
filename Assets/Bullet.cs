using UnityEngine;

public class Bullet : MonoBehaviour
{
	private float Time = 2f;

	private void Start ()
	{
		Destroy(gameObject, Time);
	}
}

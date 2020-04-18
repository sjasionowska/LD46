using UnityEngine;

public class Crosshair : MonoBehaviour
{
	UnityEngine.Camera Camera;

	void Start()
	{
		Camera = FindObjectOfType<UnityEngine.Camera>();
	}

	void Update()
	{
		// var worldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		// transform.position = (Vector2)worldPosition;
		
		// Vector3 _mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		// transform.position = new Vector3(_mousePos.x, _mousePos.y, 1);
		

	
		
	}
}

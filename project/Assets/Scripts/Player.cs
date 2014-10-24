using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	public float speed = 10f;
	private PlayerController _inputController;
	private Vector3 currentPosition;
	// Use this for initialization
	void Start () {
		_inputController = GetComponent<PlayerController>();
	}
	
	// Update is called once per frame
	void Update () {
		handleMovement ();
	}

	private void handleMovement()
	{
		if (_inputController.inputDevice == null) return;

		currentPosition = transform.position;
		currentPosition.x += speed * Time.deltaTime * _inputController.inputDevice.Direction.X;
		currentPosition.z += speed * Time.deltaTime * _inputController.inputDevice.Direction.Y;
		transform.position = currentPosition;
	}
}

﻿using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

    private const int MIN_Y = -10;

	public float speed = 10f;
	private PlayerController _inputController;
	private CharacterMotor motor;
	private Vector3 currentPosition;

    private Spawner _spawner;

    private int _playerNum;

	public bool autoRotate = true;
	public float maxRotationSpeed = 360;
	// Use this for initialization
	void Start () {
		_inputController = GetComponent<PlayerController>();
		motor = GetComponent<CharacterMotor> ();
	}
	
	// Update is called once per frame
	void Update () {
		handleMovement ();
        if (transform.position.y < MIN_Y)
            respawn();
	}

	private void handleMovement()
	{
		//if (_inputController.inputDevice == null) return;

		/*currentPosition = transform.position;
		currentPosition.x += speed * Time.deltaTime * _inputController.inputDevice.Direction.X;
		currentPosition.z += speed * Time.deltaTime * _inputController.inputDevice.Direction.Y;
		transform.position = currentPosition;*/

		var directionVector = new Vector3(_inputController.Direction.x, _inputController.Direction.y, 0);

		Debug.Log ("directionVector: " + directionVector);
		if (directionVector != Vector3.zero) {
			// Get the length of the directon vector and then normalize it
			// Dividing by the length is cheaper than normalizing when we already have the length anyway
			var directionLength = directionVector.magnitude;
			directionVector = directionVector / directionLength;
			
			// Make sure the length is no bigger than 1
			directionLength = Mathf.Min(1, directionLength);
			
			// Make the input vector more sensitive towards the extremes and less sensitive in the middle
			// This makes it easier to control slow speeds when using analog sticks
			directionLength = directionLength * directionLength;
			
			// Multiply the normalized direction vector by the modified length
			directionVector = directionVector * directionLength;
		}
		
		// Rotate the input vector into camera space so up is camera's up and right is camera's right
		directionVector = Camera.main.transform.rotation * directionVector;
		
		// Rotate input vector to be perpendicular to character's up vector
		var camToCharacterSpace = Quaternion.FromToRotation(-Camera.main.transform.forward, transform.up);
		directionVector = (camToCharacterSpace * directionVector);
		
		// Apply the direction to the CharacterMotor
		motor.inputMoveDirection = directionVector;
		motor.inputJump = _inputController.pressed(PlayerController.ACTIONS.JUMP);
		
		// Set rotation to the move direction	
		if (autoRotate && directionVector.sqrMagnitude > 0.01) {
			Vector3 newForward =  ConstantSlerp(
				transform.forward,
				directionVector,
				maxRotationSpeed * Time.deltaTime
				);
			newForward = ProjectOntoPlane(newForward, transform.up);
			transform.rotation = Quaternion.LookRotation(newForward, transform.up);
		}
	}

	Vector3 ProjectOntoPlane (Vector3 v, Vector3 normal) {
		return v - Vector3.Project(v, normal);
	}

	private Vector3 ConstantSlerp(Vector3 from, Vector3 to, float angle)
	{
		float value = Mathf.Min(1, angle / Vector3.Angle(from, to));
		return Vector3.Slerp(from, to, value);
	}

    public void setNum(int num)
    {
        _playerNum = num;
        PlayerController controller = GetComponent<PlayerController>();
        switch(num)
        {
            case 0:
                controller.controller = ControllerMapping.CONTROLLERS.KEYBOARD_1;
                break;
            case 1:
                controller.controller = ControllerMapping.CONTROLLERS.KEYBOARD_2;
                break;
            case 2:
                controller.controller = ControllerMapping.CONTROLLERS.GAMEPAD_1;
                break;
            case 3:
                controller.controller = ControllerMapping.CONTROLLERS.GAMEPAD_2;
                break;

        }
    
    }

    #region Death Functions
    public void respawn()
    {
        if(_spawner != null)
        {
            _spawner.respawn();
        }
    }

    public void setSpawner(Spawner spawner)
    {
        this._spawner = spawner;
    }
    #endregion
}

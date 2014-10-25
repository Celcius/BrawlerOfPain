using UnityEngine;
using System.Collections;

public class ReactToFloor : MonoBehaviour {
	
	private CharacterMotor motor;
	// Use this for initialization
	void Start () {
		motor = GetComponent<CharacterMotor>();
	}
	
	// Update is called once per frame
	void Update () {
		SetFloorPhysics();
	}
	
	private void SetFloorPhysics()
	{
		if (GameManager.instance.mapInfo == null) return; 
		
		GridElement cell = GameManager.instance.getCellAtWorldPosition(transform.position.x, transform.position.z);
		//Debug.Log ("current cell bloody:" + cell._isBloodied);
		if (cell._isBloodied){
			motor.movement.maxGroundAcceleration = 10;
		} else {
			motor.movement.maxGroundAcceleration = 100;
		}
	}
}

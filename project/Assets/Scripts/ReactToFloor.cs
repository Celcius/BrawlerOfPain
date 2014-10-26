using UnityEngine;
using System.Collections;

public class ReactToFloor : MonoBehaviour {
	
	private CharacterMotor motor;
	private Shadow shadow;
	
	// Use this for initialization
	void Start () {
		motor = GetComponent<CharacterMotor>();
		shadow = GetComponentInChildren<Shadow>();
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
        if (cell == null){
			shadow.gameObject.SetActive(false);
            return;
        }
		shadow.gameObject.SetActive(true);
		if (cell._isBloodied){
			motor.movement.maxGroundAcceleration = 50;
		} else {
			motor.movement.maxGroundAcceleration = 100;
		}
	}
}

using UnityEngine;
using System.Collections;

public class AlwaysFacingCamera : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 target = transform.position;
		target.z = -50;
		transform.LookAt(target);
	}
}

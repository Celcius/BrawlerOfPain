﻿using UnityEngine;
using System.Collections;

public class PickableItem : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		transform.Rotate(new Vector3(0,Time.deltaTime * 50,0));
        if (transform.position.y < -10)
            GameManager.instance.spawnVIPToken();
	}
}

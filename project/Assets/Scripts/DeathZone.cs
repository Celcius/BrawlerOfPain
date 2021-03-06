﻿using UnityEngine;
using System.Collections;

[RequireComponent (typeof (Collider))]
public class DeathZone : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () 
    {
	
	}

    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            Player player = other.GetComponent<Player>();
            if(player != null)
            {
                SoundManager.PlayFallDeath();
                player.respawn();
            }
        }

    }
}

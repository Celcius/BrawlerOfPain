using UnityEngine;
using System.Collections;

public class BloodParticles : MonoBehaviour {

    float lifeTime = 2;
    float elapsedTime = 0;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        elapsedTime += Time.deltaTime;
        if (elapsedTime > lifeTime)
            Object.Destroy(gameObject);
	}
}

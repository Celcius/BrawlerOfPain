using UnityEngine;
using System.Collections;

public class Flicker : MonoBehaviour {

    Light _light;
    float minIntensity = 0.5f;
	// Use this for initialization
	void Start () {
        _light = GetComponent<Light>();
	}
	
	// Update is called once per frame
	void Update () {
        float diff = Random.Range(-3,3)/100.0f;
        float newIntensity = _light.intensity + diff;
        float actualnew = Mathf.Clamp(newIntensity, minIntensity, 1);
        _light.intensity = actualnew;
	}
}

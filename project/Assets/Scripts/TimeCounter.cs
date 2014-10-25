using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TimeCounter : MonoBehaviour {


    Text _label;
    TimerController _controller;
    void Start()
    {



        
        _label = gameObject.GetComponentInChildren<Text>();
        _label.text = "00:00";
        _controller = GameManager.instance.controller as TimerController;
    }


	// Update is called once per frame
	void Update () {
        if(_controller != null)
           _label.text = _controller.getMinTimer()+ ":" + _controller.getSecTimer();
        else
            _controller = GameManager.instance.controller as TimerController;
	
	}
}

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
        if (_controller != null)
        {
            
            int sec = _controller.getSecTimer();
            int min = _controller.getMinTimer();

            _label.text = (min < 10 ? "0" + min : "" + min )+":" + (sec < 10 ? "0" + sec : "" + sec);
         
            if (min == 0 && sec < 30)
                _label.color = Color.red;
            else
                _label.color = Color.white;
        }
        else
            _controller = GameManager.instance.controller as TimerController;
	
	}
}

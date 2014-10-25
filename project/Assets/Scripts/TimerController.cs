using UnityEngine;
using System.Collections;

public class TimerController : GameController {

    float _gameTimer;
	// Update is called once per frame
    void Update()
    {
        switch (_state)
        {
            case GameState.GAME_OVER:
            case GameState.UNINITIALIZED:
                break;
            case GameState.PLAYING:
                _gameTimer -= Time.deltaTime*3600;
                if (_gameTimer <= 0)
                {
                    _gameTimer = 0;
                    _state = GameState.GAME_OVER;
                }
                break;

        }
      }

    public void setTimer(float time)
    {
        _gameTimer = time*3600;

        _state = GameState.PLAYING;
    }

    public string getMinTimer()
    {
        int timer = (int)_gameTimer / (216000);
        return timer < 10 ? "0" + timer : "" + timer;
    }
    public string getSecTimer()
    {
        int timer =  ((int)_gameTimer/  3600)%60;
        return timer < 10 ? "0" + timer :""+ timer;
    }
}

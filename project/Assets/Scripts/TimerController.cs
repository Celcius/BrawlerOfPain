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

    public override void startController()
    {
        float time = GameManager.instance.mapInfo.GAME_TIME * 60;
        _gameTimer = time*3600;

        _state = GameState.PLAYING;
    }

    
    public int getMinTimer()
    {
        int timer = (int)_gameTimer / (216000);
        return timer;
    }
    public int getSecTimer()
    {
        int timer =  ((int)_gameTimer/  3600)%60;
        return timer;
      
    }

}

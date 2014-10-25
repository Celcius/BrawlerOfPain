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
                _gameTimer -= Time.deltaTime;
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
        _gameTimer = time;
        GameObject ob = new GameObject();
        ob.AddComponent<GameController>();
        _state = GameState.PLAYING;
    }

}

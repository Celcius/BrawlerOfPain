using UnityEngine;
using System.Collections;

public class TimerController : GameController {

    float _gameTimer;
	// Update is called once per frame
    protected void Update()
    {
        base.Update();

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

    public override int[] getLeaderboard()
    {
        int maxScore = 0;
        int[] board = new int[GameManager.instance.mapInfo.PLAYER_COUNT];
        for (int i = 0; i < board.Length; i++)
            board[i] = -1;

        for (int i = 0; i < board.Length; i++)
        {
            for (int j = 0; j < board.Length; j++)
            {
                bool skip = false;
                for (int k = 0; k < board.Length; k++)
                    if (board[k] == j)
                        skip = true;

                if (skip)
                    continue;
                int score = getControllerCounter(j);
                if (score >= maxScore)
                {
                    maxScore = score;
                    board[i] = j;
                }
            }
            maxScore = 0;
        }

        int[] board2 = new int[board.Length];
        for (int i = board.Length - 1; i > 0; i--)
            board2[i] = board[board.Length - 1 - i];
            return board2;
    }
}

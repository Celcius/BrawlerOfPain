using UnityEngine;
using System.Collections;

public class VipController : GameController {

    int[] _playerScores;
    int _maxScore;

    float pingTime = 900;
    float elapsedTime = 0;
	// Use this for initialization
	public override void startController () 
    {
       
        _playerScores = new int[GameManager.instance.mapInfo.PLAYER_COUNT];
        for(int i = 0; i < _playerScores.Length;i++)
            _playerScores[i]=0;

        _maxScore = GameManager.instance.mapInfo.MAX_SCORE;

        GameManager.instance.spawnVIPToken();

        _state = GameState.PLAYING;
	}
	
	// Update is called once per frame
	void Update ()
    {
        base.Update();

        elapsedTime += Time.deltaTime*1000;
        if (elapsedTime >= pingTime)
        {
            elapsedTime = 0;
            Player player = GameManager.instance.vipHolder;
            if (player != null)
            {
                int num = player.getNum();
                _playerScores[num]++;
                if (_playerScores[num] > _maxScore)
                    _state = GameState.GAME_OVER;
            }
        }

	}

    public override int getControllerCounter(int playerNum)
    {
        if (playerNum < _playerScores.Length)
            return _playerScores[playerNum];
        else return 0;
    }

    public override int[] getLeaderboard()
    {
        int maxScore = 0;
        int[] board = new int[_playerScores.Length];
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
                int score = _playerScores[j];
                if (score >= maxScore)
                {
                    maxScore = score;
                    board[i] = j;
                }
            }
            maxScore = 0;
        }
        return board;
    }
}

using UnityEngine;
using System.Collections;

public class ScoreController : GameController {

        int[] _playerScores;
        int _maxPlayerScore;

        public override void startController()
        {
            _maxPlayerScore = GameManager.instance.mapInfo.MAX_SCORE;

            int players = GameManager.instance.mapInfo.PLAYER_COUNT;
            _playerScores = new int[players];
            for (int i = 0; i < players; i++)
            {
                _playerScores[i] = 0;
            }
            _state = GameState.PLAYING;
            
        }

        public override void registerPlayerDeath(int num, Player player)
        {
            base.registerPlayerDeath(num, player);

            if(player.lastHit != null)
            {
                int toScore = player.lastHit.getNum();
                if(toScore < _playerScores.Length)
                {
                    _playerScores[toScore]+=2;
                    if(_playerScores[toScore] >= _maxPlayerScore)
                    {
                        _state = GameState.GAME_OVER;
                    }
                }
            }
            else
            {
                int toSubtractScore = player.getNum();
                _playerScores[toSubtractScore] = Mathf.Max(0, _playerScores[toSubtractScore] - 1);
                
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
            for(int i = 0; i <board.Length; i++)
                board[i]= -1;

            for(int i = 0; i < board.Length;i++)
            {
                for(int j = i; j < board.Length; j++)
                {
                    int score = _playerScores[j];
                    if(score >= maxScore)
                    {
                        bool found = false;
                        for (int k = 0; k < board.Length; k++)
                            found = found || board[k] == j;

                        if(!found)
                        { 
                            maxScore = score;
                            board[i] = j;
                        }
                    }
                }
                maxScore = 0;
            }
            return board;
        }

}

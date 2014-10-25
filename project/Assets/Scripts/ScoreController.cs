using UnityEngine;
using System.Collections;

public class ScoreController : GameController {

        int[] _playerScores;
        int _maxPlayerScore;
	    
    public void setWithMaxScore(int score)
        {
            _maxPlayerScore = score;

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
                    _playerScores[toScore]++;
                    if(_playerScores[toScore] >= _maxPlayerScore)
                    {
                        _state = GameState.GAME_OVER;
                    }
                }
            }
            else
            {
                int toSubtractScore = player.getNum();
                _playerScores[toSubtractScore] = Mathf.Max(0, _playerScores[toSubtractScore] + 1);
                
            }
   
        }
    public int getPlayerScore(int playerNum)
     {
         if (playerNum < _playerScores.Length)
             return _playerScores[playerNum];
         else return 0;
     }

}

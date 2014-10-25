using UnityEngine;
using System.Collections;

public class LivesController : GameController {

    int[] playerLives;
    int[] board;
    int placeIndex;

    public override void startController()
    {

        int lives = GameManager.instance.mapInfo.LIVES;
        int players = GameManager.instance.mapInfo.PLAYER_COUNT;
        playerLives = new int[players];
        board = new int[players];
        placeIndex = players - 1;
        for (int i = 0; i < players; i++)
        {
            playerLives[i] = lives;
        }
        _state = GameState.PLAYING;

    }

    public override void registerPlayerDeath(int num, Player player)
    {
        base.registerPlayerDeath(num, player);

        playerLives[player.getNum()] = Mathf.Max(playerLives[player.getNum()]-1,0);

    }

    public bool canRespawn(int playerNum)
    {
        if (playerNum < playerLives.Length)
        {
            if(playerLives[playerNum] > 0)
                return true;
            else
            {
                board[placeIndex] = playerNum;

                if (placeIndex == 0)
                { 
                    _state = GameState.GAME_OVER;
                    for (int i = 0; i < board.Length; i++ )
                    {
                        if (playerLives[i] > 0)
                        {
                            board[0] = i;
                        }
                        
                    }
                }
                placeIndex--;
                return false;
            }
        }
        return false;
    }
    public override int getControllerCounter(int playerNum)
    {
        if (playerNum < playerLives.Length)
            return playerLives[playerNum];
        return 0;
    }

    public override int[] getLeaderboard()
    {
        return board;
    }

}

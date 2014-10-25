﻿using UnityEngine;
using System.Collections;

public class LivesController : GameController {

    int[] playerLives;


    public override void startController()
    {

        int lives = GameManager.instance.mapInfo.LIVES;
        int players = GameManager.instance.mapInfo.PLAYER_COUNT;
        playerLives = new int[players];
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
            return playerLives[playerNum] > 0;
        return false;
    }
    public override int getControllerCounter(int playerNum)
    {
        if (playerNum < playerLives.Length)
            return playerLives[playerNum];
        return 0;
    }
    
  

}
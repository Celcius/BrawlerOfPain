﻿using UnityEngine;
using System.Collections;

public class GameManager {



    protected GameManager() { }

    private static GameManager _instance = null;

     public GridElement[,] _elementMap;
     public MapGeneration mapInfo;
     public GameController controller = null;

    public ControllerMapping.CONTROLLERS[] _controllerMapping = 
        {ControllerMapping.CONTROLLERS.KEYBOARD_2,
        ControllerMapping.CONTROLLERS.KEYBOARD_1,
        ControllerMapping.CONTROLLERS.GAMEPAD_1,
        ControllerMapping.CONTROLLERS.GAMEPAD_2};
   
    public enum GameType {TIMER, SCORE, LIVES};
    public GameType gameType = GameType.TIMER;

     public static GameManager instance
     {
         get {
              if(_instance == null) 
              {
                  _instance = new GameManager();
              }

              return _instance;
     }
     }

    public void startGameOfDuration(float time)
     {
         if (mapInfo.timerHud != null)
             mapInfo.timerHud.SetActive(gameType == GameType.TIMER);
         if (mapInfo.livesHud != null)
             mapInfo.livesHud.SetActive(gameType == GameType.LIVES);
         if (mapInfo.scoreHud != null)
             mapInfo.scoreHud.SetActive(gameType == GameType.SCORE);


         if (controller != null)
             Object.Destroy(controller.gameObject);
         GameObject ob = new GameObject();
        switch(gameType)
        {
            case GameType.LIVES:
                break;
            case GameType.SCORE:

                ScoreController scoreController = ob.AddComponent<ScoreController>();
                scoreController.setWithMaxScore(mapInfo.MAX_SCORE);
                controller = scoreController as ScoreController;
                 break;
            case GameType.TIMER:
                 TimerController timeController = ob.AddComponent<TimerController>();
                 timeController.setTimer(time);
                 controller = timeController as GameController; 
                 break;
        }


       
     }

     public void setMap(GridElement[,] map, MapGeneration mapInfo)
    {
        this._elementMap = map;
        this.mapInfo = mapInfo;
    }


    public void bloodElementsAtWorldPosition(float x, float y)
    {
        int xPos = (int)(x / mapInfo.getMapScale());
        int yPos = (int)(y / mapInfo.getMapScale());
        int spray = mapInfo.getBloodSpray();

        int bloodStartX = Mathf.Max(0, xPos - spray);
        int bloodStartY = Mathf.Max(0, yPos - spray);
        int bloodEndX = Mathf.Min(_elementMap.GetLength(0), xPos + spray);
        int bloodEndY = Mathf.Min(_elementMap.GetLength(1), yPos + spray);

        for(int xVar = bloodStartX; xVar < bloodEndX; xVar ++)
            for(int yVar = bloodStartY; yVar < bloodEndY; yVar ++)
            {
                int deltaX = Mathf.Abs(xVar - xPos);
                int deltaY = Mathf.Abs(yVar - yPos);
                if(deltaX + deltaY <= spray)
                {
                    GridElement element = _elementMap[xVar, yVar];
                    if (element != null)
                        element.fillBlood(0.1f+(((spray + 1.0f) - (deltaX + deltaY)) / (float)spray)*0.9f);
                }
            }
    }
    public void setMapElement(GridElement element, int x,int y)
    {
        if(_elementMap != null)
        {
            _elementMap[x, y] = element;
        }
    }


    public void registerPlayerDeath(int playerNum, Player player)
    {
        controller.registerPlayerDeath(playerNum, player);
    }
    
    public void setPlayerMapping(ControllerMapping.CONTROLLERS mapping, int playerNum)
    {
        if(playerNum < _controllerMapping.Length)
          _controllerMapping[playerNum] = mapping;
    }

    public  ControllerMapping.CONTROLLERS getMappingForPlayer(int playerNum)
    {
        if(playerNum < _controllerMapping.Length)
           return _controllerMapping[playerNum];
        return ControllerMapping.CONTROLLERS.KEYBOARD_1;
    }
}



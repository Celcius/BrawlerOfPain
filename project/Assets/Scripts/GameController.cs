using UnityEngine;
using System.Collections;

public abstract class GameController : MonoBehaviour {
    
    public enum GameState { UNINITIALIZED, PLAYING, GAME_OVER };
    protected static GameState _state = GameState.UNINITIALIZED;

    protected int[] _playerDeaths;

    // Use this for initialization
    void Start()
    {
        int playerCount = GameManager.instance.mapInfo.PLAYER_COUNT;
        _playerDeaths = new int[playerCount];
        for (int i = 0; i < playerCount; i++)
        {
            _playerDeaths[i] = 0;
        }
    }

    protected void Update()
    {
        if(_state == GameState.GAME_OVER)
        {
            GameManager.instance.gameOver();
        }
    }

    public virtual void registerPlayerDeath(int num, Player player)
    {
        _playerDeaths[num]++;
        Debug.Log("Player " + num + " died " + _playerDeaths[num] + " times");
    }

    public abstract void startController();

    public virtual int getControllerCounter(int playerNum)
    {
        if (playerNum < _playerDeaths.Length)
            return _playerDeaths[playerNum];
        else return 0;
    }

    public abstract int[] getLeaderboard();
    

}

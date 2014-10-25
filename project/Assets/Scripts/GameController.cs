using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {
    
    enum GameState { UNINITIALIZED, PLAYING, GAME_OVER };
    static GameState _state = GameState.UNINITIALIZED;


    float _gameTimer = 0;
    int[] _playerDeaths;

	// Use this for initialization
	void Start () {
	    int playerCount = GameManager.instance.mapInfo.PLAYER_COUNT;
        _playerDeaths = new int[playerCount];
        for(int i = 0; i < playerCount; i++)
        {
            _playerDeaths[i] = 0;
        }
	} 
	
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

    public void registerPlayerDeath(int num)
    {
        _playerDeaths[num]++;
        Debug.Log("Player " + num + " died " +_playerDeaths[num] + " times");
    }

    public int[] playerDeaths()
    {
        return _playerDeaths;
    }
}

using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class PlayerCounter : MonoBehaviour {

    [SerializeField]
    int _playerNum = 0;
    int _currentCount = 0;

    int _maxTierIncrement = 20;

    Text _label;
    void Start()
    {



        _currentCount = 0;
        _label = gameObject.GetComponentInChildren<Text>();
        _label.text = "" + _currentCount;
    }

    void Update()
    {
        if (GameManager.instance.mapInfo.PLAYER_COUNT <= _playerNum)
            this.gameObject.SetActive(false);
        int counter = 0;
        if (GameManager.instance.gameType == GameManager.GameType.TIMER)
        {
            counter = GameManager.instance.controller.playerDeath(_playerNum);
        }
        else if (GameManager.instance.gameType == GameManager.GameType.SCORE)
        {
            ScoreController controller = GameManager.instance.controller as ScoreController;
            counter =  controller.getPlayerScore(_playerNum);
        }

        if (_currentCount != counter)
        {
            int increment = 2;
            if (counter < _currentCount)
                increment = -increment/2;
            _currentCount = counter;
            _label.text = "" + _currentCount;
            if (_currentCount < _maxTierIncrement)
                _label.fontSize += increment;
        }
    }
}

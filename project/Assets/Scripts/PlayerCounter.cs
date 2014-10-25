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
        if (GameManager.instance.gameType == GameManager.GameType.LIVES)
            _label.fontSize = _maxTierIncrement;
    }

    void Update()
    {
        if (GameManager.instance.mapInfo.PLAYER_COUNT <= _playerNum)
            this.gameObject.SetActive(false);
        int counter = 0;
        GameController controller = GameManager.instance.controller;
        if(controller != null)
          counter = controller.getControllerCounter(_playerNum);

        if(GameManager.instance.gameType != GameManager.GameType.LIVES)
        {
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
        else
        {
        
            if (counter == GameManager.instance.mapInfo.LIVES)
            {
                    _currentCount = counter;
                    _label.fontSize = 30;
                    _label.text = "" + _currentCount;

            }
            if (_currentCount != counter && counter < _currentCount )
            {
       
                    _currentCount = counter;
                    _label.fontSize -= 3;
                    _label.text = "" + _currentCount;
             }
        

           
        }
    }
}

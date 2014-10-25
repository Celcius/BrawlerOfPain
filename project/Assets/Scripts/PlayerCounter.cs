using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class PlayerCounter : MonoBehaviour {

    [SerializeField]
    int _playerNum = 0;
    int _deathCount = 0;

    int _maxTierIncrement = 20;

    Text _label;
    void Start()
    {
        
         

        _deathCount = 0;
        _label = gameObject.GetComponentInChildren<Text>();
        _label.text = ""+_deathCount;
    }

    void Update()
    {
        if (GameManager.instance.mapInfo.PLAYER_COUNT <= _playerNum)
            this.gameObject.SetActive(false);
        int deaths = GameManager.instance.controller.playerDeath(_playerNum);
        if (_deathCount != deaths)
        {
            _deathCount = deaths;
            _label.text = "" + _deathCount;
            if (_deathCount < _maxTierIncrement)
                _label.fontSize += 2;
        }
    }
}

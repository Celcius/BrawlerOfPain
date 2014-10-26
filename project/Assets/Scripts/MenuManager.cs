using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class MenuManager : MonoBehaviour {
    public GameObject OptionsScreen;
    public GameObject MainScreen;
    public GameObject EndScreen;

    [SerializeField]
    public Text _timedText;
    [SerializeField]
    public Text _scoreText;
    [SerializeField]
    public Text _liveText;
    [SerializeField]
    public Text _vipText;

    [SerializeField]
    public Text _playersText;

    [SerializeField]
    Toggle _timeToggle;
    [SerializeField]
    Toggle _scoreToggle;
    [SerializeField]
    Toggle _liveToggle;
    [SerializeField]
    Toggle _vipToggle;


    void Start()
    {
 
 //       OptionsScreen.SetActive(true);
   //     MainScreen.SetActive(false);
   //     EndScreen.SetActive(false);

        _playersText.text = ""+ DataHolder.instance.playerCount;
        _timedText.text = "" + DataHolder.instance.time;
        _scoreText.text = "" + DataHolder.instance.score;
        _vipText.text = "" + DataHolder.instance.vipScore;
        _liveText.text = "" + DataHolder.instance.lives;

        switch( DataHolder.instance.gameType)
        {
            case GameManager.GameType.LIVES:
                _liveToggle.isOn = true;
                break;
            case GameManager.GameType.SCORE:
                _scoreToggle.isOn = true;
                break;
            case GameManager.GameType.TIMER:

                _timeToggle.isOn = true;
                break;
            case GameManager.GameType.VIP:
                _vipToggle.isOn = true;
                break;
        }

      
    }




    public void StartGame()
    {
        int playerCount = int.Parse(_playersText.text);
        if (playerCount <= 1)
            playerCount = 2;

        float timer = float.Parse(_timedText.text);
        int score = int.Parse(_scoreText.text);
        int vipscore = int.Parse(_vipText.text);
        int lives = int.Parse(_liveText.text);
        GameManager.GameType gameType = GameManager.GameType.SCORE;
        if (_timeToggle.isOn)
        {
            gameType = GameManager.GameType.TIMER;

            Debug.Log("TIME " +timer);
        }
        else if (_scoreToggle.isOn)
        {

            gameType = GameManager.GameType.SCORE;
            Debug.Log("SCORE " +score);
        }
        else if (_liveToggle.isOn)
        {
            gameType = GameManager.GameType.LIVES;
            Debug.Log("LIVES " +lives);
        }
        else if (_vipToggle.isOn)
        {
            gameType = GameManager.GameType.VIP;
            Debug.Log("VIP " + score);
        }
        DataHolder.instance.playerCount = playerCount;
        DataHolder.instance.time = timer;
        DataHolder.instance.score = score;
        DataHolder.instance.vipScore = vipscore;
        DataHolder.instance.lives = lives;
        DataHolder.instance.gameType = gameType;
        DataHolder.instance.init();
        Application.LoadLevel("MapCreation");

    }

}

using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour {
    public GameObject MainScreen;
    public GameObject OptionsScreen;
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

    public bool _timedMode = false;
    public bool _scoreMode = true;
    public bool _livesMode = false;
    public bool _vIPMode = false;

    void Start()
    {
  //      DontDestroyOnLoad(gameObject);
        MainScreen.SetActive(false);
        EndScreen.SetActive(false);
    }




    public void StartGame()
    {
        int playerCount = int.Parse(_playersText.text);
        if (_timedMode)
        {
          
            float timer = float.Parse(_timedText.text);
            Debug.Log("TIME " +timer);
        }
        else if (_scoreMode)
        {

            int score = int.Parse(_scoreText.text);
            Debug.Log("SCORE " +score);
        }
        else if (_livesMode)
        {

            int lives = int.Parse(_liveText.text);
            Debug.Log("LIVES " +lives);
        }
        else if (_vIPMode)
        {

            int score = int.Parse(_vipText.text);
            Debug.Log("VIP " + score);
        }
        Application.LoadLevel("MapCreation");

    }

    public void ToggleTimed()
    {
        _timedMode = true;
        _scoreMode = false;
        _livesMode = false;
        _vIPMode = false;
        Debug.Log("Time " + _timedMode);

    }
    public void ToggleScore()
    {
        _timedMode = false;
        _scoreMode = true;
        _livesMode = false;
        _vIPMode = false;
        Debug.Log("Score " + _scoreMode);
    }
    public void ToggleLives()
    {
        _timedMode = false;
        _scoreMode = false;
        _livesMode = true;
        _vIPMode = false;
        Debug.Log("Lives " + _livesMode);
    }
    public void ToggleVIP()
    {
        _timedMode = false;
        _scoreMode = false;
        _livesMode = false;
        _vIPMode = true;
        Debug.Log("VIP " + _vIPMode);
    }

}

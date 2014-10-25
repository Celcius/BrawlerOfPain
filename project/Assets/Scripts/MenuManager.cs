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

    public bool _timedMode = false;
    public bool _scoreMode = true;
    public bool _livesMode = false;
    public bool _vIPMode = false;

    void Start()
    {
        DontDestroyOnLoad(gameObject);
        MainScreen.SetActive(false);
        EndScreen.SetActive(false);
    }




    public void StartGame()
    {
        if (_timedMode)
        {
            Debug.Log("TIME");


        }
        else if (_scoreMode)
        {
            Debug.Log("SCORE");
        }
        else if (_livesMode)
        {
            Debug.Log("LIVES");
        }
        else if (_vIPMode)
        {
            Debug.Log("VIP");
        }

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

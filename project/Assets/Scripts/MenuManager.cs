using UnityEngine;
using System.Collections;

public class MenuManager : MonoBehaviour {
    public GameObject MainScreen;
    public GameObject OptionsScreen;
    public GameObject EndScreen;

    void Start()
    {
        DontDestroyOnLoad(gameObject);
        MainScreen.SetActive(false);
        EndScreen.SetActive(false);
    }
	

}

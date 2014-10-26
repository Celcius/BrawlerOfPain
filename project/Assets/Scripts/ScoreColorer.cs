using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ScoreColorer : MonoBehaviour {

    [SerializeField]
    int playerNum = 1;

    void Start()
    {
        Text text = GetComponentInChildren<Text>();
        if (text != null)
            text.color = Player.playerColors[Mathf.Min(playerNum-1, 3)];
       
    }
}

using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using InControl;
public class GameOverPanel : MonoBehaviour {

    [SerializeField]
    Text [] _texts;

    [SerializeField]
    Text _pressAnyText;

    float timer = 0;
    float neededTime = 3;
    void Update ()
    {
        timer += Time.deltaTime;
        if(timer > neededTime)
        {
            _pressAnyText.gameObject.SetActive(true);
            
             if (InputManager.ActiveDevice.AnyButton.IsPressed || Input.anyKey)
             {
                GameManager.instance.startGame();
           
             }
        }
    }


    public void showGameOver()
    {
        int[] winners = GameManager.instance.getLeaderboard();

        for(int i = 0; i < 4;i++)
        {
            _texts[i].gameObject.SetActive(true);
            if (i < winners.Length)
                _texts[i].text = "Player " + (winners[i] +1);
            else
                _texts[i].gameObject.SetActive(false);
        }
        timer = 0;
        _pressAnyText.gameObject.SetActive(false);

    }
}

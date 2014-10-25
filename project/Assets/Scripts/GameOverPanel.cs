using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using InControl;
public class GameOverPanel : MonoBehaviour {

    [SerializeField]
    Text [] _texts;

    [SerializeField]
    Text _pressAnyText;

    bool showing = false;
    float elapsedTime = 0.0f;
    float neededTime = 5*60;

    void Update ()
    {
        if(showing)
        { 
          elapsedTime = elapsedTime + Time.deltaTime * 1000;
        
           if (elapsedTime > neededTime)
           {
             _pressAnyText.gameObject.SetActive(true);
            
                 if (InputManager.ActiveDevice.AnyButton.IsPressed || Input.anyKey)
              {
                   showing = false;
                   Application.LoadLevel(0);
                    //GameManager.instance.startGame();
           
              }
            }
        }
    }


    public void showGameOver()
    {
        if (showing)
            return;
        showing = true;
        int[] winners = GameManager.instance.getLeaderboard();

        for(int i = 0; i < 4;i++)
        {
            _texts[i].gameObject.SetActive(true);
            if (i < winners.Length)
                _texts[i].text = "Player " + (winners[i] +1);
            else
                _texts[i].gameObject.SetActive(false);
        }
        elapsedTime = 0;
       _pressAnyText.gameObject.SetActive(false);

    }
}

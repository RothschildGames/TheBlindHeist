using UnityEngine;
using System.Collections;

public class GameUserInterface : MonoBehaviour {

	// Use this for initialization
	void Start () {
	    
	}
	
	// Update is called once per frame
	void Update () {
        GameLogicManager logicManager = GameLogicManager.singletonInstance;
        if (logicManager.wonGame || logicManager.lostGame)
        {
            guiText.enabled = true;
            if (logicManager.wonGame)
            {
                guiText.text = "You win!";
            }
            else
            {
                guiText.text = @"You lose!";
            }
            StartCoroutine(ReturnToMainMenuAfterDelay());
        }
	}

    IEnumerator ReturnToMainMenuAfterDelay()
    {
        yield return new WaitForSeconds(3);
        Application.LoadLevel("MainMenuScene");
    }
}

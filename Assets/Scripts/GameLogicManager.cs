using UnityEngine;
using System.Collections;

public class GameLogicManager : MonoBehaviour {

    public bool wonGame;
    public bool lostGame;

    
    public static GameLogicManager singletonInstance;

	// Use this for initialization
	void Start () {
        if (singletonInstance != null)
        {
            Debug.LogError("Multiple GameLogicManager instances");
            gameObject.SetActive(false);
            return;
        }
        singletonInstance = this;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void NotifyLostGame()
	{
		Debug.Log("Lost Game!");
		wonGame = false;
		lostGame = true;
	}
	
    public void NotifyWonGame()
    {
        Debug.Log("Won Game!");
        wonGame = true;
        lostGame = false;
    }
}

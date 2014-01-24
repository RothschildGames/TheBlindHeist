using UnityEngine;
using System.Collections;

public class GameLogicManager : MonoBehaviour {

    internal bool wonGame;
	internal bool lostGame;
	public float levelDurarion = 60;
	private float remainingDuration;

    
    public static GameLogicManager singletonInstance;

	// Use this for initialization
	void Start () {
        if (singletonInstance != null)
        {
            Debug.LogError("Multiple GameLogicManager instances");
            gameObject.SetActive(false);
            return;
        }
		remainingDuration = levelDurarion;
        singletonInstance = this;
	}
	
	// Update is called once per frame
	void Update () {
		if (!isOver()) {
			remainingDuration = Mathf.Max(remainingDuration - Time.deltaTime, 0);
			if (remainingDuration == 0) {
				NotifyLostGame();
			}
		}
	}

	public void NotifyLostGame()
	{
		if (!isOver()) {
			Debug.Log ("Lost Game!");
			wonGame = false;
			lostGame = true;
		}
	}
	
    public void NotifyWonGame()
    {
		if (!isOver()) {
			Debug.Log ("Won Game!");
			wonGame = true;
			lostGame = false;
		}
    }

	public bool isOver() {
		return (wonGame || lostGame);
	}
}

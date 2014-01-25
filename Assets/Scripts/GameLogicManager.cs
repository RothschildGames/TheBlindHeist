using UnityEngine;
using System.Collections;

public class GameLogicManager : MonoBehaviour {
	public CameraManager cameraManager;
	public HackerUI hackerUI;
	public PlayAudio audioTracks;

    internal bool wonGame;
	internal bool lostGame;
	public float levelDurarion = 60;
	private float remainingDuration;
    
    public static GameLogicManager singletonInstance;

	// Use this for initialization
	void Awake () {
        Application.targetFrameRate = 60;
        if (singletonInstance != null)
        {
            Debug.LogError("Multiple GameLogicManager instances");
            gameObject.SetActive(false);
            return;
        }
		singletonInstance = this;
	}

	void Start () {
		remainingDuration = levelDurarion;
		if (GameRole.singletonInstance.IsRunner || !GameRole.singletonInstance.IsNetworkGame) {
			audioTracks.StartGame();
		}
	
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

	void OnSerializeNetworkView(BitStream stream, NetworkMessageInfo info) {
		if (stream.isWriting) {
				float duration = remainingDuration;
				bool won = wonGame;
				bool lost = lostGame;
				stream.Serialize (ref duration);
				stream.Serialize (ref won);
				stream.Serialize (ref lost);
		} else {
				float duration = 0;
				bool won = false;
				bool lost = false;
				stream.Serialize (ref duration);
				stream.Serialize (ref won);
				stream.Serialize (ref lost);
				remainingDuration = duration;
				wonGame = won;
				lostGame = lost;
		}
	}

	public void NotifyLostGame()
	{
		if (!isOver()) {
			Debug.Log ("Lost Game!");
			wonGame = false;
			lostGame = true;
			cameraManager.initEndGame(false);
			hackerUI.lost();
			audioTracks.lost();
		}
	}
	
    public void NotifyWonGame()
    {
		if (!isOver()) {
			Debug.Log ("Won Game!");
			wonGame = true;
			lostGame = false;
			cameraManager.initEndGame(true);
			hackerUI.won();
			audioTracks.won();
		}
    }

	public bool isOver() {
		return (wonGame || lostGame);
	}

	public float GetRemainingDuration()
	{
		return remainingDuration;
	}
}

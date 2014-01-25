using UnityEngine;
using System.Collections;

public class GameUserInterface : MonoBehaviour {

    private static float rotationAngle = 0;
    
    public Texture2D compassTexture;
    public Rect compassRect = new Rect(50, 0, 256, 256);
    public Transform playerTransform;

	public OVRCameraController controller;

    void OnGUI()
    {

		if (!OVRDevice.IsSensorPresent(0)) {
						//rotating 256x256 GUITexture in a GUI Group:
						GUI.BeginGroup (compassRect);
						GUIUtility.RotateAroundPivot (rotationAngle, new Vector2 (compassRect.width / 2, compassRect.height / 2));
						GUI.DrawTexture (new Rect (0, 0, compassRect.width, compassRect.height), compassTexture);
						GUI.EndGroup ();
				}
    }

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
            //StartCoroutine(ReturnToMainMenuAfterDelay());
        }
        rotationAngle = -playerTransform.rotation.eulerAngles.y;
	}

    IEnumerator ReturnToMainMenuAfterDelay()
    {
		// TODO: Need to check PlayAudio.isDone() before moving away.
        yield return new WaitForSeconds(3);
        Application.LoadLevel("MainMenuScene");
    }
}

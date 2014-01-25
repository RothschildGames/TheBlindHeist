using UnityEngine;
using System.Collections;

public class MenuUserInterface : MonoBehaviour {

	private NetworkManager networkManager;
	
	public GUIStyle style;
	public GUIStyle creditStyle;
	public GUIStyle inputStyle;


	// Use this for initialization
	void Start () {
		networkManager = GetComponent<NetworkManager> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnGUI () {
		
		float center = Screen.width/2;
		float buttonWidth = 300;
		float buttonHeight = 60;
		float startY = 300;
		float buttonMargin = 10;
		
		float buttonX = center - buttonWidth/2;
		
		float roomX = buttonX + buttonWidth + buttonMargin;
		float roomW = 200;
		//			float roomY = startY
		if (!Network.isClient && !Network.isServer) {

			if (GUI.Button (new Rect (buttonX, startY, buttonWidth, buttonHeight), "PLAY LOCALLY", style)) {
				Application.LoadLevel ("LevelScene");
			}

			float button2Y = startY + (buttonHeight + buttonMargin);
			if (GUI.Button (new Rect (buttonX, button2Y, buttonWidth, buttonHeight), "HOST SERVER", style)) {
				networkManager.StartServer ();
			}

			if (networkManager.GetHostList() == null) {
				creditStyle.alignment = TextAnchor.UpperLeft;
				GUI.Label (new Rect (roomX, button2Y, roomW, 30), "ROOM NAME:", creditStyle);

				creditStyle.alignment = TextAnchor.MiddleLeft;
				networkManager.roomName = GUI.TextField(new Rect(roomX, button2Y + 25 , roomW, 25), networkManager.roomName);
			}

			float button3Y = startY + (buttonHeight + buttonMargin) * 2;
			if (GUI.Button (new Rect (buttonX, button3Y, buttonWidth, buttonHeight), "JOIN GAME", style)) {
				networkManager.RefreshHostList ();
			}				
			if (networkManager.GetHostList() != null) {
				creditStyle.alignment = TextAnchor.UpperLeft;
				GUI.Label (new Rect (roomX, startY, roomW, 30), "OPEN ROOMS:", creditStyle);
				for (int i = 0; i < networkManager.GetHostList().Length; i++) {
					if (GUI.Button (new Rect (roomX, startY + 30 + 40 * (i), buttonWidth, 30), networkManager.GetHostList() [i].gameName)) {
						networkManager.JoinServer (networkManager.GetHostList() [i]);
					}
				}
			}
			creditStyle.alignment = TextAnchor.UpperCenter;
			GUI.Label (new Rect (buttonX, Screen.height - 60, buttonWidth, 60), "MADE WITH LOVE #GGJ14 TLV\nAH, ES, IM, MS, NG, SD, YB", creditStyle);


		} else if (Network.isServer) {
			if (GUI.Button (new Rect (buttonX, startY + 40, buttonWidth, buttonHeight), "START GAME", style)) {
				Application.LoadLevel ("LevelScene");
			}
			creditStyle.alignment = TextAnchor.MiddleCenter;
			int playersConnected = networkManager.CountConnectedUsers();
			GUI.Label (new Rect (buttonX, startY, buttonWidth, 30), "WAITING FOR PLAYERS: " + playersConnected + " CONNECTED", creditStyle);

		} 

	}
}

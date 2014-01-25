using UnityEngine;
using System.Collections;

public class MenuUserInterface : MonoBehaviour {

	private NetworkManager networkManager;


	// Use this for initialization
	void Start () {
		networkManager = GetComponent<NetworkManager> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnGUI () {

		if (!Network.isClient && !Network.isServer) {
			
			if (GUI.Button (new Rect (30, 220, 300, 60), "Start Local Game")) {
				Application.LoadLevel ("LevelScene");
			}
			
			if (GUI.Button (new Rect (30, 290, 300, 60), "Host Server")) {
				networkManager.StartServer ();
			}

			GUI.Label (new Rect (340, 290, 200, 30), "Room name:");

			networkManager.roomName = GUI.TextField(new Rect(340, 320, 300, 30), networkManager.roomName);
			
			if (GUI.Button (new Rect (30, 360, 300, 60), "Join Existing Game")) {
				networkManager.RefreshHostList ();
			}				
			if (networkManager.GetHostList() != null) {
				for (int i = 0; i < networkManager.GetHostList().Length; i++) {
					if (GUI.Button (new Rect (340, 360 * (1 + i), 300, 60), networkManager.GetHostList() [i].gameName)) {
						networkManager.JoinServer (networkManager.GetHostList() [i]);
					}
				}
			}

		} else if (Network.isServer) {
			if (GUI.Button (new Rect (30, 220, 300, 60), "Start Game")) {
				Application.LoadLevel ("LevelScene");
			}
		} 

	}
}

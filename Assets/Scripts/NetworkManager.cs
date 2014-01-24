using UnityEngine;
using System.Collections;

public class NetworkManager : MonoBehaviour {
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	
	private const string typeName = "o11";
	private const string gameName = "o11";
	
	private void StartServer()
	{
		Network.InitializeServer(4, 25000, !Network.HavePublicAddress());
		MasterServer.RegisterHost(typeName, gameName);
	}
	
	
	
	void OnServerInitialized()
	{
		Debug.Log("Server Initializied");
	}
	
	
	void OnGUI()
	{
		if (!Network.isClient && !Network.isServer) {

			if (GUI.Button (new Rect (30, 200, 300, 60), "Start Local Game")) {
				Application.LoadLevel ("LevelScene");
			}

			if (GUI.Button (new Rect (30, 270, 300, 60), "Host Server")) {
				StartServer ();
			}
			
			if (GUI.Button (new Rect (30, 340, 300, 60), "Join Existing Gamer")) {
				RefreshHostList ();
			}				
			
			if (hostList != null) {
				for (int i = 0; i < hostList.Length; i++) {
					if (GUI.Button (new Rect (30, 410 * (1 + i), 300, 60), hostList [i].gameName))
						JoinServer (hostList [i]);
				}
			}
		} else if (Network.isServer) {
			if (GUI.Button (new Rect (30, 200, 300, 60), "Start Game")) {
				Application.LoadLevel ("LevelScene");
			}
		} 
		
	}
	
	private HostData[] hostList;
	
	private void RefreshHostList()
	{
		MasterServer.RequestHostList(typeName);
	}
	
	void OnMasterServerEvent(MasterServerEvent msEvent)
	{
		if (msEvent == MasterServerEvent.HostListReceived)
			hostList = MasterServer.PollHostList();
		
		else if (msEvent == MasterServerEvent.RegistrationSucceeded)
			Debug.Log ("server registered");
	}
	
	private void JoinServer(HostData hostData)
	{
		Debug.Log("connecting to: " + hostData.gameName);
		Network.Connect(hostData);
		Application.LoadLevel ("LevelScene");
	}
	
	void OnConnectedToServer()
	{
		Debug.Log("Server Joined");
	}
	
	
	
	
}


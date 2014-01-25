using UnityEngine;
using System.Collections;

public class NetworkManager : MonoBehaviour {

	public string roomName = "My Heist";

	private const string typeName = "Blind Heist";
	private HostData[] hostList;


	//******** host code

	public void StartServer()
	{
		Network.InitializeServer(4, 25000, !Network.HavePublicAddress());
		MasterServer.RegisterHost(typeName, roomName);
	}

	void OnServerInitialized()
	{
		Debug.Log("Server Initializied");
	}
	

	public void RefreshHostList()
	{
		MasterServer.RequestHostList(typeName);
	}

	public HostData[] GetHostList()
	{
		return hostList;
	}
	
	void OnMasterServerEvent(MasterServerEvent msEvent)
	{
		if (msEvent == MasterServerEvent.HostListReceived) {
			hostList = MasterServer.PollHostList ();
		}
		else if (msEvent == MasterServerEvent.RegistrationSucceeded)
			Debug.Log ("server registered");
	}



	//******** client code

	public void JoinServer(HostData hostData)
	{
		Debug.Log("connecting to: " + hostData.gameName);
		Network.Connect(hostData);
	}
	
	void OnConnectedToServer()
	{
		Debug.Log("Server Joined");
        Application.LoadLevel("LevelScene");
	}
	
	
	
	
}


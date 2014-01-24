using UnityEngine;
using System.Collections;

public class NetworkManager : MonoBehaviour {
	
	void Start () {}
	
	void Update () {}

	private const string typeName = "o11";
	private const string gameName = "o11";
	private HostData[] hostList;


	//******** host code

	public void StartServer()
	{
		Network.InitializeServer(4, 25000, !Network.HavePublicAddress());
		MasterServer.RegisterHost(typeName, gameName);
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
	}
	
	
	
	
}


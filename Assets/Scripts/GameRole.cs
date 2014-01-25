using UnityEngine;
using System.Collections;

public class GameRole : MonoBehaviour {

    public static GameRole singletonInstance;
    public bool isLocalPlayerRunner;

    void Awake()
    {
        if (singletonInstance != null)
        {
            Debug.LogError("Multiple GameRole objects exist");
            return;
        }
        singletonInstance = this;
    }

    public bool IsRunner
    {
        get
        {
            if (Network.isServer)
            {
                Debug.Log("IsRunner = true because server");
                return true;
            }
            if (Network.isClient)
            {
                Debug.Log("IsRunner = false because client");
                return false;
            }
            Debug.Log("IsRunner = " + isLocalPlayerRunner.ToString() + " because local");
            return isLocalPlayerRunner;
        }
    }

    public bool IsNetworkGame
    {
        get
        {
            bool retVal = (Network.isClient || Network.isServer);
            Debug.Log("IsNetworkGame = " + retVal.ToString());
            return retVal;
        }
    }
	
}

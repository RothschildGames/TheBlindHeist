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
                return true;
            }
            if (Network.isClient)
            {
                return false;
            }
            return isLocalPlayerRunner;
        }
    }
	
}

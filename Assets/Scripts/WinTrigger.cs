using UnityEngine;
using System.Collections;

public class WinTrigger : MonoBehaviour {

    public bool win = true;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("WinTrigger triggered with " + other.gameObject.name);
        if (other.gameObject.name == "Player")
        {
            if (win)
            {
                GameLogicManager.singletonInstance.NotifyWonGame();
            }
            else
            {
                GameLogicManager.singletonInstance.NotifyLostGame();
            }
            
        }
    }
}

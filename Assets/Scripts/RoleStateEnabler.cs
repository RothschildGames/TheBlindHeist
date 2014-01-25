using UnityEngine;
using System.Collections;

public class RoleStateEnabler : MonoBehaviour {

    public bool allowRunner;
    public bool allowHacker;
    public bool alwaysOnIfLocal;

    public GameObject[] gameObjects;
    public Behaviour[] components;

    private bool IsAllowed
    {
        get
        {
            if (alwaysOnIfLocal && !GameRole.singletonInstance.IsNetworkGame)
            {
                return true;
            }
            if (GameRole.singletonInstance.IsRunner)
            {
                return allowRunner;
            }
            else
            {
                return allowHacker;
            }
        }
    }

    void Awake()
    {
        foreach (GameObject go in gameObjects)
        {
            go.SetActive(IsAllowed);
        }
        foreach (Behaviour c in components)
        {
            c.enabled = IsAllowed;
        }
    }
}

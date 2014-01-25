using UnityEngine;
using System.Collections.Generic;

public class WalkOrIdleAnimation : MonoBehaviour {

    private Queue<Vector3> positionHistory;
    public int framesToRemember = 15;

    private AnimationState WalkState
    {
        get { return animation["walk"]; }
    }

    private AnimationState IdleState
    {
        get { return animation["idle"]; }
    }

    private float MovementDelta
    {
        get
        {
            return (transform.position - positionHistory.Peek()).magnitude / Time.deltaTime;
        }
    }
    
	// Use this for initialization
	void Start () {
        positionHistory = new Queue<Vector3>();
	}

    bool IsWalking
    {
        get { return WalkState.weight > 0; }
        set
        {
            if (value)
            {
                Debug.Log("Walking");
                animation.Play("walk", PlayMode.StopAll);
            }
            else
            {
                Debug.Log("Idling");
                animation.Play("idle", PlayMode.StopAll);
            }
        }
    }

    bool ShouldWalk
    {
        get
        {
            Debug.Log("Movement delta = " + MovementDelta);
            return MovementDelta > 0.1;
        }
    }
	// Update is called once per frame
	void LateUpdate () {
        positionHistory.Enqueue(transform.position);
        while (positionHistory.Count > framesToRemember)
        {
            positionHistory.Dequeue();
        }

        if (IsWalking != ShouldWalk)
        {
            IsWalking = ShouldWalk;
        }
	}
}

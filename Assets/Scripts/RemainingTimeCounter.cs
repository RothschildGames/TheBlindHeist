using UnityEngine;
using System.Collections;

public class RemainingTimeCounter : MonoBehaviour 
{
	public GUIText gText;
	
	void Update()
	{
		float remainingDuration = GameLogicManager.singletonInstance.GetRemainingDuration();
		if (remainingDuration < 0)
		{
			remainingDuration = 0; // clamp the timer to zero
		}
		
		int seconds = (int)remainingDuration % 60; // calculate the seconds
		int minutes = (int)remainingDuration / 60; // calculate the minutes
		gText.text = minutes.ToString("D2") + ":" + seconds.ToString("D2");
	}
}
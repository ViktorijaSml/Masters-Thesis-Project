﻿using System.Collections;
using UnityEngine;
public class TimerFunctions : MonoBehaviour
{
	public static TimerFunctions instance;
	private bool isTimerActive = false;
	int timeout = 0;
    public void Awake()
    {
        instance = this; 
    }
      
    public void  InitWatchDogTimer(int miliseconds) => StartCoroutine(StartWatchdogTimer(miliseconds));

	public void FeedWatchdogTimer()
	{
        Debug.Log("Feed WDT");
        isTimerActive = true;
	}
    IEnumerator StartWatchdogTimer(int miliseconds)
	{
		float timer = miliseconds/1000f;
		timeout = miliseconds;
			while (timer > 0f)
			{
				if (isTimerActive)
				{
					isTimerActive = false;
					timer = miliseconds/1000f;
				}
				else
				{
					yield return new WaitForSeconds(1f);
				    Debug.Log((int)timer);
					timer -= 1f;
				}
			}
		throw new System.Exception("Watchdog timer has finished! There must be an error!");		
	}

	public bool IsActive() => isTimerActive;
	public void StopTimer()
	{
		StopCoroutine(StartWatchdogTimer(timeout));
	}
}


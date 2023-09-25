using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pause : MonoBehaviour
{
	private bool pause;

	public void PauseGame()
	{
		if (pause) 
		{
			Time.timeScale = 1;
		}
		else
		{
			Time.timeScale = 0;
		}
		pause = !pause;
	}
}

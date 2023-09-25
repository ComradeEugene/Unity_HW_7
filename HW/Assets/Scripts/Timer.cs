using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
	private Image img;
	public bool tick;
	public int count;
	private float currentTime;
	private float maxTime;
	private AudioSource clip;

	private void Start()
	{
		img = GetComponent<Image>();
		tick = false;
		currentTime = 0;
		clip = GetComponent<AudioSource>();
	}

	void Update()
	{
		if (tick && currentTime < maxTime)
		{
			currentTime += Time.deltaTime;
			img.fillAmount = currentTime / maxTime;
		}
		else if (tick && currentTime >= maxTime) 
		{
			tick = false;
			currentTime = 0;
			img.fillAmount = 0;
			count++;
			clip.Play();
		}
	}

	public void StartTimer(float newTime)
	{
		tick = true;
		maxTime= newTime;
	}
}

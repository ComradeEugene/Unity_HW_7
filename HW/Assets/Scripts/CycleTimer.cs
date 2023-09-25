using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CycleTimer : MonoBehaviour
{
	public float maxTime;
	private float currentTime;
	private Image img;
	private AudioSource clip;
	public bool tick;

	// Start is called before the first frame update
	void Start()
	{
		currentTime = maxTime;
		img = GetComponent<Image>();
		clip = GetComponent<AudioSource>();
	}

	// Update is called once per frame
	void Update()
	{
		tick = false;
		currentTime -= Time.deltaTime;

		if (currentTime <= 0)
		{
			tick = true;
			currentTime = maxTime;
			clip.Play();
		}

		img.fillAmount = currentTime / maxTime;
	}
}

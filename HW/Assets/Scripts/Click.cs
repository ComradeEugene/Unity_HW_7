using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Click : MonoBehaviour
{
	private AudioSource click;

	private void Start()
	{
		click = GetComponent<AudioSource>();
	}

	public void ButtonClick()
	{
		click.Play();
	}
}

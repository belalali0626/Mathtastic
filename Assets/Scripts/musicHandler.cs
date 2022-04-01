using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class musicHandler : MonoBehaviour
{
	public void ButtonClick()
	{
		FindObjectOfType<AudioManager>().Play("click1");
	}
	public void StartClick()
	{
		FindObjectOfType<AudioManager>().Play("start");
	}
}

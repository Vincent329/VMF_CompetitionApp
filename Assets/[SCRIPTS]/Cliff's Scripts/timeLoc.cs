using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;
using UnityEngine.SceneManagement;

public class timeLoc : MonoBehaviour
{
	public string realTime;
	public Text timeText;
	public Text locText;
	public AudioClip scene;
	public AudioSource audioSrc;
	private int rHeading;
	private int adjHeading;
	private int playIndex = 0;
    // Start is called before the first frame update
    void Start()
    {
		Screen.sleepTimeout = SleepTimeout.NeverSleep;
		Input.location.Stop();
		Input.compass.enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
		if(GlobalVar2.dockIndex > 0 && playIndex == 0)
		{
			scene = Resources.Load<AudioClip>("sceneM");
			audioSrc.clip = scene;
			audioSrc.volume = 0.7f;
			audioSrc.Play();
			playIndex = 1;
		}
		rHeading = (int)Mathf.Round(Input.compass.trueHeading);
		realTime = System.DateTime.Now.ToString("HHmmddMMMMyyyy");
		timeText.text = "Time: " + System.DateTime.Now.ToString("HH:mm dd MMMM, yyyy");
		//locText.text = "Location: Markville Shopping Centre";
		
			if(rHeading >= 350f || rHeading <= 10f)
			{
				if(GlobalVar.visionIndex == 0)
				{
					locText.text = "Location: Millennium Park, Markham" + "\n" + "Compass: N";
				}
				else
				{
					locText.text = "Location: Moon" + "\n" + "Compass: N";
				}
			}
			else if(rHeading > 10f && rHeading < 80f)
			{
				adjHeading = rHeading;
				if(GlobalVar.visionIndex == 0)
				{
					locText.text = "Location: Millennium Park, Markham" + "\n" + "Compass: N" + adjHeading + "E";
				}
				else
				{
					locText.text = "Location: Moon" + "\n" + "Compass: N" + adjHeading + "E";
				}
			}
			else if(rHeading >= 80f && rHeading <= 100f)
			{
				if(GlobalVar.visionIndex == 0)
				{
					locText.text = "Location: Millennium Park, Markham" + "\n" + "Compass: E";
				}
				else
				{
					locText.text = "Location: Moon" + "\n" + "Compass: E";
				}
			}
			else if(rHeading > 100f && rHeading < 170f)
			{
				adjHeading = 180 - rHeading;
				if(GlobalVar.visionIndex == 0)
				{
					locText.text = "Location: Millennium Park, Markham" + "\n" + "Compass: S" + adjHeading + "E";
				}
				else
				{
					locText.text = "Location: Moon" + "\n" + "Compass: S" + adjHeading + "E";
				}
			}
			else if(rHeading >= 170f && rHeading <= 190f)
			{
				if(GlobalVar.visionIndex == 0)
				{
					locText.text = "Location: Millennium Park, Markham" + "\n" + "Compass: S";
				}
				else
				{
					locText.text = "Location: Moon" + "\n" + "Compass: S";
				}
			}
			else if(rHeading > 190f && rHeading < 260f)
			{
				adjHeading = rHeading - 180;
				if(GlobalVar.visionIndex == 0)
				{
					locText.text = "Location: Millennium Park, Markham" + "\n" + "Compass: S" + adjHeading + "W";
				}
				else
				{
					locText.text = "Location: Moon" + "\n" + "Compass: S" + adjHeading + "W";
				}
			}
			else if(rHeading >= 260f && rHeading <= 280f)
			{
				if(GlobalVar.visionIndex == 0)
				{
					locText.text = "Location: Millennium Park, Markham" + "\n" + "Compass: W";
				}
				else
				{
					locText.text = "Location: Moon" + "\n" + "Compass: W";
				}
			}
			else if(rHeading > 280f && rHeading < 350f)
			{
				adjHeading = 360 - rHeading;
				if(GlobalVar.visionIndex == 0)
				{
					locText.text = "Location: Millennium Park, Markham" + "\n" + "Compass: N" + adjHeading + "W";
				}
				else
				{
					locText.text = "Location: Moon" + "\n" + "Compass: N" + adjHeading + "W";
				}
			}
    }
}

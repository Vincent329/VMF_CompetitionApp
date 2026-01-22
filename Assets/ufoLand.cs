using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;
using UnityEngine.SceneManagement;

public class ufoLand : MonoBehaviour
{
	public float waitIndex = 1f;
	public float dirIndex = 1f;
	public float dirIndexRot = 1f;
	public Vector3 initPos;
    // Start is called before the first frame update
    void Start()
    {
		
		//GameObject.Find("cake").transform.position = new Vector3(0, 100f, 0);
		//GameObject.Find("cake").transform.Rotate(0, 2f, 0, Space.World);
		
		//initPos = new Vector3(0, 20f, 0);
		StartCoroutine("wait");
		StartCoroutine("move");
    }

    // Update is called once per frame
    void Update()
    {
		if(GlobalVar2.dockIndex > 0)
		{
			/* GameObject.FindWithTag("JIP").transform.Translate(0, 0.1f*dirIndex*Time.deltaTime, 0); */
			GameObject.FindWithTag("heart").transform.Rotate(0, 1.5f, 0, Space.World);
			GameObject.FindWithTag("jip").transform.Translate(0, 0.1f*dirIndex*Time.deltaTime, 0);
			GameObject.FindWithTag("adorabilis").transform.Rotate(2f*dirIndexRot*Time.deltaTime, 0, 0);
			GameObject.FindWithTag("adorabilis").transform.Translate(0, 0, 0.02f*dirIndexRot*Time.deltaTime);
		//GameObject.FindWithTag("JIP").transform.Rotate(0, 1.5f, 0, Space.World);
		//GameObject.Find("champUFO").transform.position = new Vector3(0, 12f, 0);
		}
    }
	
	IEnumerator wait()
	{
		while (true)
		{
			yield return new WaitForSeconds(1f/*0.15f*/);
			//waitIndex = waitIndex + 1f;
			if (dirIndexRot != 1f)
			{	
				dirIndexRot = 1f;
			}
			else
			{
				dirIndexRot = -1f;
			}
		}
		
	}
	
	IEnumerator move()
	{
		while (true)
		{
			yield return new WaitForSeconds(0.25f/*0.15f*/);
			
			if (dirIndex != 1f)
			{	
				dirIndex = 1f;
			}
			else
			{
				dirIndex = -1f;
			}
		}
		
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sceneSwitch : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
		if(GlobalVar.visionIndex == 0)
		{
			GameObject.Find("sideCylinder").transform.localScale = new Vector3(0, 0, 0);
			GameObject.Find("botCylinder").transform.localScale = new Vector3(0, 0, 0);
			GameObject.Find("topCylinder").transform.localScale = new Vector3(0, 0, 0);
		}
		else
		{
			GameObject.Find("sideCylinder").transform.localScale = new Vector3(5f, 1.5f, 5f);
			GameObject.Find("botCylinder").transform.localScale = new Vector3(5f, 0f, 5f);
			GameObject.Find("topCylinder").transform.localScale = new Vector3(5f, 0f, 5f);
		}
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class panelDisappear : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
		if(GlobalVar.scanIndex == 1)
			GameObject.Find("Panel").transform.localScale = new Vector3(0f, 0f, 0f);
        
    }
}

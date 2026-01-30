using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vision : MonoBehaviour
{	
    // Start is called before the first frame update
    public void changeView()
    {
       GlobalVar.visionIndex++;
	   if(GlobalVar.visionIndex > 1) {
		   GlobalVar.visionIndex = 0;
	   }
		
    }

    // Update is called once per frame
   /*  void Update()
    {
        
    } */
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MenuNext : MonoBehaviour {
	
	public void MNext() {
		//if(GlobalVar.gDistance <= 25f)
		GlobalVar2.dockIndex = 0;
		GlobalVar.nextIndex = 1;
		GlobalVar.visionIndex = 0;
		SceneManager.LoadScene(0); /* Default: 1 */
		/* Application.LoadLevel(1); */
	}
}

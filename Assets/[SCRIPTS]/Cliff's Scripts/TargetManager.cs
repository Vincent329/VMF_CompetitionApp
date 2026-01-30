using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetManager : MonoBehaviour
{
	private PlaceIndicator placeIndicator;
	private GameObject newPlacedObject;
	public GameObject objectToPlace;
	
    // Start is called before the first frame update
    void Start()
    {
		//newPlacedObject.SetActive(false);
        
    }

    // Update is called once per frame
    public void ClickToPlace()
    {
		if(GlobalVar2.dockIndex == 0)
		{
			placeIndicator = FindObjectOfType<PlaceIndicator>();
			
			newPlacedObject = Instantiate(objectToPlace, placeIndicator.transform.position, placeIndicator.transform.rotation);
			//GlobalVar2.dockIndex++;
			GlobalVar2.dockIndex = 1;
		}
    }
}

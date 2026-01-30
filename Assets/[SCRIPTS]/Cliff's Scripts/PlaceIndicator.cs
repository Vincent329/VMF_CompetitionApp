using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public static class GlobalVar2
{
	 public static int dockIndex = 0;
}

public class PlaceIndicator : MonoBehaviour
{
	public float waitIndex = 0;
	private ARRaycastManager raycastManager;
	private GameObject indicator;
	private List<ARRaycastHit> hits = new List<ARRaycastHit> ();

	private PlayerInput playerInput;

	private InputAction touchPressAction;

    private void Awake()
    {
        playerInput = GetComponent<PlayerInput>();
		touchPressAction = playerInput.actions["Click"];
    }

    private void OnEnable()
    {
		touchPressAction.performed += TouchPressed;
    }

    private void OnDisable()
    {
		touchPressAction.performed -= TouchPressed;
    }

    // Start is called before the first frame update
    void Start()
    {
		GlobalVar2.dockIndex = 0;
		
		/* GameObject.FindWithTag("ufo").transform.position = new Vector3(0, 200f, 0);
		GameObject.FindWithTag("ufo").transform.Rotate(0, 1.5f, 0, Space.World); */
        raycastManager = FindObjectOfType<ARRaycastManager> ();
		indicator = transform.GetChild(0).gameObject;
		//indicator.SetActive(false);
		StartCoroutine("wait");
    }

    // Update is called once per frame
    void Update()
    {
		//var ray2 = new Vector2(Screen.width/2f, Screen.height/2f);
		
		if(waitIndex > 2000f)
		{
			GameObject.FindWithTag("panel1").transform.localScale = new Vector3(0, 0, 0);
		}
		
		if(GlobalVar2.dockIndex != 0)
		{
			/* GameObject.Find("Indicator").transform.localScale = new Vector3(0, 0, 0); */
			indicator.SetActive(false);
			//Destroy(indicator);
		}
		else
		{
			/* GameObject.Find("Indicator").transform.localScale = new Vector3(1f, 1f, 1f); */
			indicator.SetActive(true);
			var ray2 = new Vector2(Screen.width/2f, Screen.height/2f);
			
		if(raycastManager.Raycast(ray2, hits, TrackableType.Planes))
		{
			Pose hitPose = hits[0].pose;
			transform.position = hitPose.position;
			transform.rotation = hitPose.rotation;
			
			if(!indicator.activeInHierarchy)
			{
				indicator.SetActive(true);	
			}
		}
		}
    }
	
	IEnumerator wait()
	{
		while (true)
		{
			yield return new WaitForSeconds(1f/*0.15f*/);
			waitIndex = waitIndex + 100f;
		}
		
	}

	private void TouchPressed(InputAction.CallbackContext context)
	{
        GameObject.FindWithTag("panel1").transform.localScale = new Vector3(0, 0, 0);
    }
}

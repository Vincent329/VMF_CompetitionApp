using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GlobalVar
{
    public static int audioIndex = 0;
	public static int scanIndex = 0;
	public static int nextIndex = 0;
	public static int visionIndex = 0;
	public static float targetLat = /*43.8843667f*/43.8685527f/*43.6576624f /*10.44893f*/;
    public static float targetLon = /*-79.2321701f*/-79.289192f/*-79.3813766f/*-73.26962f*/;
	public static float userLat = 0;
	public static float userLon = 0;
	public static float userFlag = 0; /* 1 */
	public static float userAngle2 = 0;
	public static float vFlag0 = 0;
	public static float gDistance = 9999f;
	public static float mrDistance = 0;
	public static float gAngle = 0;
	public static float height = 0;
}

public class gVar : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

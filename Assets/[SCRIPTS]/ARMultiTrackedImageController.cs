using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

[RequireComponent(typeof(ARTrackedImageManager))]
public class ARMultiTrackedImageController : MonoBehaviour
{
    [SerializeField]
    private ARTrackedImageManager m_TrackedImageManager;
    [SerializeField]
    private List<GameObject> foodPrefabs;
    private List<GameObject> m_spawnedFoodItems = new List<GameObject>();

    [SerializeField]
    [Tooltip("The camera to set on the world space UI canvas for each instantiated image info.")]
    Camera m_WorldSpaceCanvasCamera;

    /// <summary>
    /// The prefab has a world space UI canvas,
    /// which requires a camera to function properly.
    /// </summary>
    public Camera worldSpaceCanvasCamera
    {
        get { return m_WorldSpaceCanvasCamera; }
        set { m_WorldSpaceCanvasCamera = value; }
    }

    private void Awake()
    {
        m_TrackedImageManager = GetComponent<ARTrackedImageManager>();
        m_WorldSpaceCanvasCamera = GetComponentInChildren<Camera>();
          
    }

    private void OnEnable()
    {
        m_TrackedImageManager.trackablesChanged.AddListener(OnChangeTrackingState);
        foreach (var food in foodPrefabs)
        {
            var spawnedItem = Instantiate<GameObject>(food);
            string foodID = spawnedItem.gameObject.name;
            spawnedItem.SetActive(false);
            m_spawnedFoodItems.Add(spawnedItem);
        }
    }

    private void OnDisable()
    {
        m_TrackedImageManager.trackablesChanged.RemoveListener(OnChangeTrackingState);
      
    }

    async Task UpdateInfo(ARTrackedImage trackedImage)
    {
        if (trackedImage.trackingState != TrackingState.None)
        {
            // The image extents is only valid when the image is being tracked
            trackedImage.transform.localScale = new Vector3(trackedImage.size.x, 1f, trackedImage.size.y);

            foreach (var foodItem in m_spawnedFoodItems)
            {
                if (trackedImage.referenceImage.name + "(Clone)" == foodItem.name)
                {
                    foodItem.SetActive(true);
                    foodItem.transform.SetPositionAndRotation(trackedImage.transform.position, trackedImage.transform.rotation);
                }
            }

        }
        //else
        //{
        //    foreach (var foodItem in m_spawnedFoodItems)
        //    {
        //        foodItem?.SetActive(false);
        //    }
        //}
    }

    void OnChangeTrackingState(ARTrackablesChangedEventArgs<ARTrackedImage> eventArgs)
    {
        foreach(ARTrackedImage trackedImage in eventArgs.added)
        {
            trackedImage.transform.localScale = new Vector3(0.01f, 1f, 0.01f);
            UpdateInfo(trackedImage);
        }
        foreach (ARTrackedImage trackedImage in eventArgs.updated)
        {
            UpdateInfo(trackedImage);
        }
        foreach(var trackedImage in eventArgs.removed)
        {
            //foreach (var foodItem in m_spawnedFoodItems)
            //{
            //    foodItem.SetActive(false);
            //}
        }
    }
}

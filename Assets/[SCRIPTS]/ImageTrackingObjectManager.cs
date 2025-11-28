using NUnit.Framework;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.XR;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

[RequireComponent(typeof(ARTrackedImageManager))]
public class ImageTrackingObjectManager : MonoBehaviour
{

    [SerializeField]
    [Tooltip("Image manager on the AR Session Origin")]
    ARTrackedImageManager m_ImageManager;

    [SerializeField]
    XRReferenceImageLibrary m_ImageLibrary;

    /// <summary>
    /// Get the <c>ARTrackedImageManager</c>
    /// </summary>
    public ARTrackedImageManager ImageManager
    {
        get => m_ImageManager;
        set => m_ImageManager = value;
    }


    [SerializeField]
    [Tooltip("The prefab list for QR codes and Food Items to test with")]
    private List<GameObject> m_PlacableFoodPrefabs;

    public Dictionary<string, GameObject> spawnedFoodPrefabs;
    
    private void Awake()
    {
        m_ImageManager = GetComponent<ARTrackedImageManager>();
        if (m_ImageManager == null) return;
        m_ImageManager.referenceLibrary = m_ImageLibrary;
        m_ImageManager.trackablesChanged.AddListener(OnImagesTrackedChanged);
        spawnedFoodPrefabs = new Dictionary<string, GameObject>();
        LoadSceneElements();
    }


    private void OnDestroy() { m_ImageManager.trackablesChanged.RemoveListener(OnImagesTrackedChanged); }
    

    private void LoadSceneElements()
    {
        foreach (var prefab in m_PlacableFoodPrefabs)
        {
            var arObject = Instantiate(prefab, Vector3.zero, Quaternion.identity);
            arObject.name = prefab.name;
            arObject.gameObject.SetActive(false);
            spawnedFoodPrefabs.Add(arObject.name, prefab);
        }

    }

    void OnImagesTrackedChanged(ARTrackablesChangedEventArgs<ARTrackedImage> obj)
    {
        foreach (var trackedImage in obj.added)
        {
           UpdateImage(trackedImage);
        }
        foreach (var trackedImage in obj.updated)
        {
            UpdateImage(trackedImage);
        }
        foreach (var trackedImage in obj.removed)
        {
            UpdateImage(trackedImage.Value);
            //spawnedFoodPrefabs[trackedImage.Value.name].gameObject.SetActive(false);
        }
    }

    private void UpdateImage(ARTrackedImage trackedImage)
    {
        if (trackedImage == null) return;
        // Debug.Log("Name: " + trackedImage.name);
        if (trackedImage.trackingState is TrackingState.Limited or TrackingState.None)
        {
            spawnedFoodPrefabs[trackedImage.referenceImage.name].gameObject.SetActive(false);
            return;
        }

        spawnedFoodPrefabs[trackedImage.referenceImage.name].gameObject.SetActive(true);
        spawnedFoodPrefabs[trackedImage.referenceImage.name].gameObject.transform.position = trackedImage.transform.position;
        spawnedFoodPrefabs[trackedImage.referenceImage.name].gameObject.transform.rotation = trackedImage.transform.rotation;

    }

}

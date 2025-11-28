using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;
using UnityEngine.XR.Interaction.Toolkit.Samples.StarterAssets;

public abstract class Reader : ARTrackableManager<XRImageTrackingSubsystem,
        XRImageTrackingSubsystemDescriptor,
        XRImageTrackingSubsystem.Provider,
        XRTrackedImage,
        ARTrackedImage>
{

    private QRCodeReader qrCodeReader;
    Dictionary<Int32, XRReferenceImage> m_ReferenceImages = new Dictionary<Int32, XRReferenceImage>();

    /// <summary>
    /// Get or set the reference image library (that is, the set of images to search for in the physical environment).
    /// </summary>
    /// <remarks>
    /// An <c>IReferenceImageLibrary</c> can be either an <c>XRReferenceImageLibrary</c>
    /// or a <c>RuntimeReferenceImageLibrary</c>. <c>XRReferenceImageLibrary</c>s can only be
    /// constructed in the Editor and are immutable at runtime. A <c>RuntimeReferenceImageLibrary</c>
    /// is the runtime representation of a <c>XRReferenceImageLibrary</c> and can be mutable
    /// at runtime (see <c>MutableRuntimeReferenceImageLibrary</c>).
    /// </remarks>
    /// <exception cref="System.InvalidOperationException">Thrown if the <see cref="referenceLibrary"/> is set to <c>null</c> while image tracking is enabled.</exception>
    public IReferenceImageLibrary referenceLibrary
    {
        get
        {
            if (subsystem != null)
            {
                return subsystem.imageLibrary;
            }
            else
            {
                return qrCodeReader.serializedLibrary;
            }
        }

        set
        {
            if (value == null && subsystem != null && subsystem.running)
                throw new InvalidOperationException("Cannot set a null reference library while image tracking is enabled.");

            if (value is XRReferenceImageLibrary serializedLibrary)
            {
                qrCodeReader.serializedLibrary = serializedLibrary;
                if (subsystem != null)
                    subsystem.imageLibrary = subsystem.CreateRuntimeLibrary(serializedLibrary);
            }
            else if (value is RuntimeReferenceImageLibrary runtimeLibrary)
            {
                qrCodeReader.serializedLibrary = null;
                EnsureSubsystemInstanceSet();

                if (subsystem != null)
                    subsystem.imageLibrary = runtimeLibrary;
            }

            if (subsystem != null)
                UpdateReferenceImages(subsystem.imageLibrary);
        }
    }

    void UpdateReferenceImages(RuntimeReferenceImageLibrary library)
    {
        if (library == null)
            return;

        int count = library.count;
        for (int i = 0; i < count; ++i)
        {
            var referenceImage = library[i];

            int hashCode = referenceImage.guid.GetHashCode();
            m_ReferenceImages[hashCode] = referenceImage;
        }
    }
}

[RequireComponent(typeof(ObjectSpawner),typeof(ARCameraManager))]
public class QRCodeReader : MonoBehaviour
{
    [SerializeField]
    private ARCameraManager m_CameraManager;

    [SerializeField]
    private ARTrackedImageManager m_ImageManager;


    [SerializeField]
    [FormerlySerializedAs("m_ReferenceLibrary")]
    [Tooltip("The library of images which will be detected and/or tracked in the physical environment.")]
    XRReferenceImageLibrary m_SerializedLibrary;

    public XRReferenceImageLibrary serializedLibrary
    {
        get { return m_SerializedLibrary; }
        set { m_SerializedLibrary = value; }
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        m_CameraManager = GetComponent<ARCameraManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

}

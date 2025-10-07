// FaceTrackingEventHandler.cs
using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class FaceTrackingEventHandler : MonoBehaviour
{
    [SerializeField] private ARFaceManager faceManager;
    [SerializeField] private UIManager uiManager;

    void OnEnable()
    {
        faceManager.facesChanged += OnFacesChanged;
    }

    void OnDisable()
    {
        faceManager.facesChanged -= OnFacesChanged;
    }

    private void OnFacesChanged(ARFacesChangedEventArgs eventArgs)
    {
        // Check if any faces are currently being tracked.
        if (faceManager.trackables.count > 0)
        {
            // If we have at least one face, show the UI.
            uiManager.ShowUIForFaceDetected();
        }
        else
        {
            // If no faces are tracked, hide the UI.
            uiManager.HideAllUI();
        }
    }
}
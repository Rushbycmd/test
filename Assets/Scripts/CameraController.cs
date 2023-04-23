using UnityEngine;
using System;

public class CameraController : MonoBehaviour
{
    public Camera[] cameras; // an array of cameras to cycle through
    public float switchInterval = 5.0f; // the interval at which to switch cameras

    private int currentCameraIndex = 0;
    private float timeSinceLastSwitch = 0.0f;

    private void Start()
    {
        // ensure that the first camera is active
        ActivateCamera(currentCameraIndex);
    }

    private void Update()
    {
        timeSinceLastSwitch += Time.deltaTime;

        if (timeSinceLastSwitch >= switchInterval)
        {
            timeSinceLastSwitch = 0.0f;
            currentCameraIndex = (currentCameraIndex + 1) % cameras.Length;
            ActivateCamera(currentCameraIndex);
        }
    }

    private void ActivateCamera(int index)
    {
        // deactivate all cameras except the one at the specified index
        for (int i = 0; i < cameras.Length; i++)
        {
            cameras[i].gameObject.SetActive(false);
        }

        // activate the camera with the corresponding name
        string cameraName = "CM" + (index + 1).ToString();
        Camera cameraToActivate = Array.Find(cameras, c => c.name == cameraName);

        if (cameraToActivate != null)
        {
            cameraToActivate.gameObject.SetActive(true);
        }
        else
        {
            Debug.LogWarning($"Camera with name {cameraName} not found!");
        }
    }

}

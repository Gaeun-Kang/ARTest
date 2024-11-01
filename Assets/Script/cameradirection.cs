using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class cameradirection : MonoBehaviour
{
    public ARCameraManager arCameraManager;
    void Start()
    {
        arCameraManager.requestedFacingDirection = CameraFacingDirection.User;
    }

}

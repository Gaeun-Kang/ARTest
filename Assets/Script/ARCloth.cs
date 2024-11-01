using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using Unity.XR.CoreUtils;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.XR.ARCore;
using UnityEngine.XR.ARFoundation;

public class ARCloth : MonoBehaviour
{
    [SerializeField]

    private GameObject TrackingCloth;
    private ARFaceManager facemanager;
    private XROrigin xrorigin;

    private GameObject clothobject;

    private NativeArray<ARCoreFaceRegionData> faceRegions;

    private void Awake()
    {
        facemanager = GetComponent<ARFaceManager>();
        xrorigin = GetComponent<XROrigin>();
    }

    // Update is called once per frame
    private void Update()
    {
        //subsystem
        ARCoreFaceSubsystem subsystem = (ARCoreFaceSubsystem)facemanager.subsystem;

        //tracking data 
        foreach(ARFace face in facemanager.trackables)
        {

            subsystem.GetRegionPoses(face.trackableId, Allocator.Persistent, ref faceRegions);

            foreach (ARCoreFaceRegionData faceRegion in faceRegions)
            {
                ARCoreFaceRegion regionType = faceRegion.region;

                if (regionType == ARCoreFaceRegion.NoseTip)
                {

                    if (!clothobject)
                    {
                        clothobject = Instantiate(TrackingCloth, xrorigin.TrackablesParent);

                    }

                  }
               
            }

        }

    }
}

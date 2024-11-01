using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation; //필수 추가 

public class FaceSwitcher : MonoBehaviour
{
    [SerializeField]
    private Material[] materials;
    private ARFaceManager faceManager;
    private int index = 0;

    private void Start()
    {
        faceManager = GetComponent<ARFaceManager>(); //가져오기 
    }

    private void Update()
    {
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            index = (index + 1) % materials.Length; //머테리얼 배열 인덱스 증가 및 범위 내에서 순환

            foreach (ARFace face in faceManager.trackables)
            {
                face.GetComponent<MeshRenderer>().material = materials[index];
            }
        }
    }


}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation; //�ʼ� �߰� 

public class FaceSwitcher : MonoBehaviour
{
    [SerializeField]
    private Material[] materials;
    private ARFaceManager faceManager;
    private int index = 0;

    private void Start()
    {
        faceManager = GetComponent<ARFaceManager>(); //�������� 
    }

    private void Update()
    {
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            index = (index + 1) % materials.Length; //���׸��� �迭 �ε��� ���� �� ���� ������ ��ȯ

            foreach (ARFace face in faceManager.trackables)
            {
                face.GetComponent<MeshRenderer>().material = materials[index];
            }
        }
    }


}

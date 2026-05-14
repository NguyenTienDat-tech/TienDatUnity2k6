using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraPlayer : MonoBehaviour
{
    private Transform cameraMario;


    private void Awake()
    {
        cameraMario = GameObject.FindWithTag("player").transform;
    }

    private void LateUpdate()
    {
        Vector3 ViTri = transform.position;
        //ViTri.x = camera.position.x;
        ViTri.x = Mathf.Max(ViTri.x, cameraMario.position.x); //Camera chỉ sang phải, không quay lại
        transform.position = ViTri;
    }


}

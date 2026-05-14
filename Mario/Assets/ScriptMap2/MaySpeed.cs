using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaySpeed : MonoBehaviour
{
    public float Speed = 2f;
    public float DiemBienMat = -15f;
    public float DiemXuatHien = 15f;

    private void Update()
    {
        Vector3 ViTri = transform.position;
        ViTri.x -= Speed * Time.deltaTime;
        transform.position = ViTri;


        if (transform.position.x < DiemBienMat)
        {
            ViTri.x = DiemXuatHien;
            transform.position = ViTri;
        }



    }

}

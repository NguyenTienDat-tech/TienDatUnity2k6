using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockSpeed : MonoBehaviour
{
    public float Speed = 2f;
    public float DiemBienMat = -35f;
    public float DiemXuatHien = 35f;

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

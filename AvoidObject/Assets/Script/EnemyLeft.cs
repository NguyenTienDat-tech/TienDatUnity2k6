using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy7 : MonoBehaviour
{
    public GameObject Prefad;
    public Transform ViTri;



    
    void Start()
    {
        InvokeRepeating("SpawnEnemy", 1, 2);
        
    }

    private void SpawnEnemy()
    {
        if (Prefad != null && ViTri != null)
        {
            PoolingManager.Spawn(Prefad, ViTri.position, Quaternion.identity);
        }
        
    }

}

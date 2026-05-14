using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class rainCoint : MonoBehaviour
{
    public GameObject Coint;
    public float spawnHeight = 10f;

    void Start()
    {
        InvokeRepeating("SpawnCointWave", 2f, 1f);
    }

   
    void SpawnCointWave()
    {
        int cointCount = Random.Range(2, 6);

        for (int i = 0; i < cointCount; i++)
        {
            SpawnCoint();
        }
    }

    void SpawnCoint()
    {
        if (Coint != null)
        {
            float random = Random.Range(-8f, 8f);
            float randomNgauNhien = Random.Range(0f, 2f);
            Vector3 gacha = new Vector3(random, spawnHeight + randomNgauNhien, 0);
            // Tạo ra quái vật tại vị trí của Spawner
            PoolingManager.Spawn(Coint, gacha, Quaternion.identity);
        }
    }
}

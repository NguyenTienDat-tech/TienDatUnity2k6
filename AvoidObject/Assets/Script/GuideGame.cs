using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuideGame : MonoBehaviour
{
    public GameObject Guide;
    public void HienThi()
    {
        Guide.SetActive(true);
    }

    public void Cancel()
    {
        Guide.SetActive(false);
    }
}

using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.UI;

public class PlayerParry : MonoBehaviour
{
    public int liveParry = 5;
    [SerializeField] Image[] parry;

    private int maxParry; //Số khiên tối đa
    private float regenTime = 3f; // thời gian hồi
    private float timer;

    private void Awake()
    {
        maxParry = parry.Length; //gán giá trị bằng số lượng hình ảnh kéo vào
        liveParry = maxParry;
    }

    public void ManagerParry()
    {
        liveParry--;
        parry[liveParry].enabled = false;
        timer = 0;
    }


    public void RegenParry()
    {
        parry[liveParry].enabled = true;
        liveParry++;
    }

    private void Update()
    {
        if (liveParry < maxParry)
        {
            timer += Time.deltaTime;

            if (timer > regenTime)
            {
                RegenParry();
                timer = 0;
            }
        }
    }


}


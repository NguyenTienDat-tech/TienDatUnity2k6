using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class Score : MonoBehaviour
{
    public TextMeshProUGUI ScoreText;
    private float DiemHienTai = 0f;
    private float DiemTangMoiGiay = 10f;
    public static bool isPlayerAlive = true;
    


    void Start()
    {
        this.DiemHienTai = 0f;
        isPlayerAlive = true;
    }




    void Update()
    {
        if (isPlayerAlive)
        {
            this.DiemHienTai += DiemTangMoiGiay * Time.deltaTime;
            ScoreText.text = "Score: " + Mathf.FloorToInt(DiemHienTai).ToString();
        } 
        else if(!isPlayerAlive)
        {
            ScoreText.text = "Score: " + Mathf.FloorToInt(DiemHienTai).ToString();
        }
    }
}

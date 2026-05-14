using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ManagerEnermy : MonoBehaviour
{
    public Image Enermy;
    public TextMeshProUGUI textMeshPro;


    public void UpdateEnermy(int currentGeneral, int maxGeneral)
    {
        Enermy.fillAmount = (float)currentGeneral / (float)maxGeneral;
        textMeshPro.text = currentGeneral.ToString() + "/" + maxGeneral.ToString();
    }



}

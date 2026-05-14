using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ManagerHeal : MonoBehaviour
{
    public Image fillBar;
    public TextMeshProUGUI textHeal;
   

    public void UpdateBar(int mauHienTai, int mauToiDa)
    {
        fillBar.fillAmount = (float) mauHienTai / (float) mauToiDa;
        textHeal.text = mauHienTai.ToString() + " / " + mauToiDa.ToString();
    }
}

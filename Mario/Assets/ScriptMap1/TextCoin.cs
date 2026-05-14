using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TextCoin : MonoBehaviour
{
    public TextMeshProUGUI textMeshPro;
    public int coin = 0;
    public void ChuCoin()
    {
        coin++;
        textMeshPro.text = ": " + coin.ToString();
    }
}

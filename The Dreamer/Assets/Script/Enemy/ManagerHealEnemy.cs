using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ManagerHealEnemy : MonoBehaviour
{
    public Image Enemy;


    public void UpdateEnemy(int currentGeneral, int maxGeneral)
    {
        Enemy.fillAmount = (float)currentGeneral / (float)maxGeneral;
    }
}

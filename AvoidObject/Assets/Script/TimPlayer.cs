using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimPlayer : MonoBehaviour
{
    public int live = 5;
    public Image[] heal;
    public Player player;
    public GameObject GameOver;


    public void healTim()
    {
        live--;
        heal[live].enabled = false;

        if (live == 0)
        {
            Destroy(gameObject, 0.5f);
            player.AnimationDeath();
            GameOver.SetActive(true);
            Time.timeScale = 0f;
        }
    }


}

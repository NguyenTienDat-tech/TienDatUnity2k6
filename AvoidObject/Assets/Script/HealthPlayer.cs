using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPlayer : MonoBehaviour
{
    private int mauHienTai;
    public int mauToiDa;
    public ManagerHeal managerHeal;
    public GameObject GameOver;
  
    void Start()
    {
        mauHienTai = mauToiDa;
        managerHeal.UpdateBar(mauHienTai, mauToiDa);
    }

    public void TakeDamager(int Damager)
    {
        mauHienTai -= Damager;

        managerHeal.UpdateBar(mauHienTai, mauToiDa);

        if (mauHienTai <= 0)
        {
            Destroy(gameObject);
            GameOver.SetActive(true);
            Score.isPlayerAlive = false;
            Time.timeScale = 0f;
        }
        
    }

}

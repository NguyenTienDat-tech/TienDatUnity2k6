using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealMario : MonoBehaviour
{
    public int Lives = 5;
    public Image[] heal;
    public Mario mario;
    public ManagerGame game;
    private float timeCho;

    public void live()
    {
        Lives--;
        heal[Lives].enabled = false;

        if (Lives == 0)
        {
            mario.DaChet = true;
            timeCho = Time.time + 0.2f;
            game.ResetLever();
        }
    }
}

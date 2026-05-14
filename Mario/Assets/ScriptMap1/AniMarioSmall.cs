using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows;

public class AniMarioSmall : MonoBehaviour
{
    public Animator animator;
    public Mario mario;


    private void AnimationMario()
    {
        bool Chay = Mathf.Abs(mario.dichuyen) > 0.1f;
        animator.SetBool("Run", Chay);

        bool Nhay = (mario.KiemTra == false);
        animator.SetBool("Jump", Nhay);

        bool dangphanh = Mathf.Abs(mario.dichuyen) <= 0.1f;
        animator.SetBool("KetThucSpeed", dangphanh);
        

        

    }

   private void Death()
    {
        if (mario.DaChet == true)
        {
            animator.SetBool("Death", true);
            animator.SetBool("Run", false);
            animator.SetBool("Jump", false);
        }
    }


    private void Update()
    {
        AnimationMario();
        Death();
    }


}

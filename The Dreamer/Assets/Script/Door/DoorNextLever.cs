using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorNextLever : MonoBehaviour
{
    [SerializeField] ManagerGame game;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            game.NextLever();
        }
    }
}

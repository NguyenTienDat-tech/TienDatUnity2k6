using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public abstract class ManagerPickGun : MonoBehaviour
{
    protected CircleCollider2D circle;

    [SerializeField] protected GameObject bottonE;
    private bool isCheckPlayer = false;

    [SerializeField] DataWeapon newWeapon;
    protected GameObject player;
  

    protected virtual void Start()
    {
        circle = GetComponent<CircleCollider2D>();
        if (bottonE != null)
        {
            bottonE.SetActive(false);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isCheckPlayer = true;
            player = collision.gameObject;
            if (bottonE != null)
            {
                bottonE.SetActive(true);
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isCheckPlayer = false;
            player = null;
            if (bottonE != null)
            {
                bottonE.SetActive(false);
            }
        }
    }

    private void OpenGun()
    {
        if (bottonE != null)
        {
            bottonE.SetActive(false);
        }

        Gun();
    }



    protected abstract void Gun();

    private void Update()
    {
        if (isCheckPlayer && Input.GetKeyDown(KeyCode.E))
        {
            OpenGun();
        }
    }



}

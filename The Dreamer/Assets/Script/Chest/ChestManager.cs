using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public abstract class ChestManager : MonoBehaviour
{
    protected BoxCollider2D box;
    protected CircleCollider2D circle;
    [SerializeField] protected Animator animator;

    [SerializeField] protected GameObject bottonE;
    private bool isCheckPlayer = false;
    private bool isOpen = false;

    protected virtual void Start()
    {
        box = GetComponent<BoxCollider2D>();
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
            if (bottonE != null)
            {
                bottonE.SetActive(false);
            }
        }
    }

    private void OpenChest()
    {
        isOpen = true;

        if (bottonE != null)
        {
            bottonE.SetActive(false);
        }

        Chest();

        box.enabled = false;
        circle.enabled = false;
    }

    

    protected abstract void Chest();

    private void Update()
    {
        if (isCheckPlayer &&  !isOpen && Input.GetKeyDown(KeyCode.E))
        {
            OpenChest();
        }
    }



}

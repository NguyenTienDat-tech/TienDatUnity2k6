using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Door : MonoBehaviour
{
    [SerializeField] GameObject CloseDoor1;
    [SerializeField] GameObject OpenDoor1;

    public void CloseDoor()
    {
        CloseDoor1.SetActive(true);
        OpenDoor1.SetActive(false);
    }

    public void OpenDoor()
    {
        CloseDoor1.SetActive(false);
        OpenDoor1.SetActive(true);
    }
}

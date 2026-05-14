using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
    [SerializeField] Transform locationPlayer;

    private void LateUpdate()
    {
        Vector3 location = new Vector3(locationPlayer.position.x, locationPlayer.position.y, -10);
        transform.position = location;
    }
}

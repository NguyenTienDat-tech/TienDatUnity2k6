using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckRoom : MonoBehaviour
{
    [SerializeField] Transform roomTransform;
    [SerializeField] LayerMask playerPrefab;
    protected bool isPlayer = false;

    [SerializeField] Vector2 roomSize = new Vector2(10f, 8f);

    

    protected virtual void Update()
    {
        bool checkPlayer = Physics2D.OverlapBox(roomTransform.position, roomSize, 0, playerPrefab);

        if (checkPlayer != isPlayer)
        {
            isPlayer = checkPlayer;
            OnSetActiveEnemy(isPlayer);
        }
    }

    protected virtual void OnSetActiveEnemy(bool isInside)
    {

    }


    

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        if (roomTransform != null)
        {
            // Vẽ cái khung dây theo kích thước roomSize bạn đang chỉnh
            Gizmos.DrawWireCube(roomTransform.position, roomSize);
        }
    }
}

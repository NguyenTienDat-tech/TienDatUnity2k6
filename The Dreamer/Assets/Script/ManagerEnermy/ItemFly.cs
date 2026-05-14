using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class ItemFly : MonoBehaviour
{
    [SerializeField] float Speed = 15f;

    private Transform playerTransform;
    private bool isFly = false; //kiểm tra bay

    private void Start()
    {
        GameObject player = GameObject.FindWithTag("Player");
        if (player != null )
        {
            playerTransform = player.transform;
        }
    }

    private void OnEnable()
    {
        isFly = false;

        // Nhảy ngẫu nhiên ra xung quanh 1 khoảng nhỏ trong 0.5 giây
        Vector3 Fly = transform.position + (Vector3)UnityEngine.Random.insideUnitCircle * 1.5f;

        // Nhảy đến randomPos, độ cao 1, trong 0.5 giây. 
        // Sau khi nhảy xong thì đợi 0.5s rồi mới bật isFly
        transform.DOJump(Fly, 1f, 1, 0.5f).OnComplete(() =>
        {
            Invoke(nameof(EnableFly), 0.5f); // Đợi thêm 0.5s cho đẹp rồi mới bay
        });
    }

    private void OnDisable()
    {
        transform.DOKill();
        CancelInvoke(nameof(EnableFly));
    }

    private void EnableFly()
    {
        isFly = true;
    }

    private void Update()
    {
        if (isFly && playerTransform != null)
        {
            transform.position = Vector3.MoveTowards(transform.position, playerTransform.position, Speed * Time.deltaTime);
        }
    }
}
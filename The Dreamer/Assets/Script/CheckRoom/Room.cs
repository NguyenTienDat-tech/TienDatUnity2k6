using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room : CheckRoom
{
    [SerializeField] List<EnemyBase> Enemy;
    [SerializeField] List<BaseBoss> BaseBoss;
    [SerializeField] List<Door> doors;


    private bool isRoomClear = false;

    private void Start()
    {
        CloseAllDoor();
        SetEnemyActive(false);
    }


    protected override void OnSetActiveEnemy(bool isInside)
    {
        if (isRoomClear)
        {
            return;
        }

        CloseAllDoor();
        SetEnemyActive(isInside);
    }

    private void SetEnemyActive(bool isPlayer)
    {
        foreach (var enemy in Enemy)
        {
            if (enemy != null)
            {
                enemy.enabled = isPlayer;

                enemy.room = this;

                Animator ani = enemy.GetComponent<Animator>();

                if (ani != null)
                {
                    ani.enabled = isPlayer;
                }
            }
        }
    }

    private void CloseAllDoor()
    {
        foreach (var door in doors)
        {
            if (door != null)
            {
                door.CloseDoor();
            }
        }
    }

    public void OpenAllDoor()
    {
        foreach (var door in doors)
        {
            if (door != null)
            {
                door.OpenDoor();
            }
        }
    }

    public void RoomClear()
    {
        if (Enemy.Count == 0)
        {
            isRoomClear = true;
            OpenAllDoor();
        }
    }

    public void RemoveEnemy(EnemyBase deadEnemy)
    {
        if (Enemy.Contains(deadEnemy))
        {
            Enemy.Remove(deadEnemy);
        }

        if (Enemy.Count == 0)
        {
            RoomClear();
        }
    }

    public void RemoveBoss(BaseBoss dealBoss)
    {
        if (BaseBoss.Contains(dealBoss))
        {
            BaseBoss.Remove(dealBoss);
        }

        if (BaseBoss.Count == 0)
        {
            RoomClear();
        }
    }


}

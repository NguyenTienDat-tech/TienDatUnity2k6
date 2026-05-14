using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ChestKhoBau : ChestManager
{
    [SerializeField] GameObject Gun;


    private void Start()
    {
        base.Start();
    }
    protected override void Chest()
    {
        SpawnItem(Gun);
    }

    private void SpawnItem(GameObject ItemPrefad)
    {
        if (ItemPrefad == null)
        {
            return;
        }

        GameObject item = PoolingManager.Spawn(ItemPrefad, transform.position, Quaternion.identity);


        if (AudioManager.instance != null)
        {
            AudioManager.instance.PlayAudioClip(AudioManager.instance.openChest);
        }

        animator.SetTrigger("KhoBau");
    }
}

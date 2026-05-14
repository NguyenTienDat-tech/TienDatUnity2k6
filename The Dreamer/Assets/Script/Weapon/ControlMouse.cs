using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class ControlMouse : MonoBehaviour
{
    public Transform firePoint;
    [SerializeField] Camera camera;


    public DataWeapon currentWeapon;
    private float nextTime; //thời gian chờ tiếp theo
    public PlayerEnermy enermy;

    public Animator animator;
    [SerializeField] PlayerControlWeapon weapon;

    private void Shoot()
    {
        animator.SetTrigger("isShoot");

        for (int i = 0; i < currentWeapon.quantity; i++)
        {
            //Độ tỏa của đạn
            float currentAngle = firePoint.eulerAngles.z;
            float random = Random.Range(-currentWeapon.radiate, currentWeapon.radiate);
            Quaternion bulletRotation = Quaternion.Euler(0, 0, currentAngle + random);


            //Spawn đạn
            GameObject bullet = PoolingManager.Spawn(currentWeapon.SpriteBullet, firePoint.position, bulletRotation);
            Bullet spriteBullet = bullet.GetComponent<Bullet>();
            if (bullet != null)
            {
                spriteBullet.Setup(currentWeapon.speed, currentWeapon.damage);
            }
        }
        enermy.TakeDamage(currentWeapon.enermyLost);
        firePoint.transform.DOLocalMoveX(-0.2f, 0.05f).OnComplete(() => firePoint.transform.DOLocalMoveX(0, 0.05f));
    }

    public void Mouse()
    {
        //Nếu PauseGame thì ngừng hoạt động luôn
        if (Time.timeScale == 0)
        {
            return;
        }

        //dành cho đạn cần năng lượng
        if (enermy.HasEnoughEnergy(currentWeapon.enermyLost) == true)
        {
            if (currentWeapon.weaponName == "Shootgun" || currentWeapon.weaponName == "SniperRifle" || currentWeapon.weaponName == "Pistol")
            {
                if (Input.GetButtonDown("Fire1") && Time.time >= nextTime)
                {
                    Shoot();
                    nextTime = Time.time + currentWeapon.loadTime;

                    if (AudioManager.instance != null)
                    {
                        AudioManager.instance.PlayAudioClip(AudioManager.instance.gunShortClip);
                    }
                }
            }
            else
            {
                if (Input.GetButton("Fire1") && Time.time >= nextTime)
                {
                    Shoot();
                    nextTime = Time.time + currentWeapon.loadTime;

                    if (AudioManager.instance != null)
                    {
                        AudioManager.instance.PlayAudioClip(AudioManager.instance.gunShortClip);
                    }
                }
            }
        }
        //dành cho đạn không cần năng lượng
        else if (currentWeapon.weaponName == "Pistol")
        {
            if (Input.GetButtonDown("Fire1") && Time.time >= nextTime)
            {
                Shoot();
                nextTime = Time.time + currentWeapon.loadTime;
            }
        }

        

        //Điểm bắn đi theo hướng con trỏ chuột
        Vector3 Mouse = camera.ScreenToWorldPoint(Input.mousePosition);
        Vector2 direction = Mouse - firePoint.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg; //Tính góc quay dựa trên vector hướng
        firePoint.rotation = Quaternion.Euler(0, 0, angle);

        if (firePoint.transform.eulerAngles.z > 90 && firePoint.transform.eulerAngles.z < 270)
        {
            firePoint.transform.localScale = new Vector3(1, -1, 1);
        }
        else
        {
            firePoint.transform.localScale = new Vector3(1, 1, 1);
        }
    }


    private void Update()
    {
        Mouse();
        currentWeapon = weapon.currentWeapon;
    }


}

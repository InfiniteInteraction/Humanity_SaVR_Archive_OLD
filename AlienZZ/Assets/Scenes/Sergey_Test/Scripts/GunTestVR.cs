using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GunTestVR : MonoBehaviour
{
    public Transform spawnPoint; //Point the raycast will originate from
    public LayerMask layerMask; //The layer mask that detects enemy
    public float damageValue = 0;
    [Header("Ammo")]
    public int currAmmo = 10;
    public int maxAmmo = 20;
    public int ammoReturn = 3;
    int bulletCount;
    [Header("Weapon Firing")]
    public bool canShoot = true;
    public bool fullAutoMode = false;
    public float currTime = 0;
    public float shootTime = 0;
    public float fullAutoTime;
    public float semiAutoTime = 0;

    GameObject green;
    GameObject red;
    GameObject greenBullet;
    GameObject redBullet;
    GameObject waveBullet;

    bool shootOnce;

    private void Awake()
    {
        green = GetComponentInChildren<ID_Green>().gameObject;
        red = GetComponentInChildren<ID_Red>().gameObject;
        greenBullet = Resources.Load(("Prefabs/PlasmaBulletGreen"), typeof(GameObject)) as GameObject;
        redBullet = Resources.Load(("Prefabs/PlasmaBulletRed"), typeof(GameObject)) as GameObject;
        waveBullet = Resources.Load(("Prefabs/WaveBullet"), typeof(GameObject)) as GameObject;
        fullAutoTime = 0.1f;
        shootOnce = false;
    }

    void Start()
    {
        
        damageValue = 1;
        red.SetActive(false);
    }

    

    void Update()
    {
        
        if (fullAutoMode)
        {
            if (OVRInput.Get(OVRInput.Button.PrimaryIndexTrigger) && canShoot && currAmmo > 0)
            {
                Shoot();
            }
        }
        else
        {

            if ((OVRInput.GetDown(OVRInput.RawButton.LIndexTrigger) )  && canShoot && currAmmo > 0)
            {
                StartCoroutine("OneShot");
                return;
            }
            if ((OVRInput.GetUp(OVRInput.RawButton.LIndexTrigger) ) && !canShoot)
            {
                canShoot = true;
                return;
            }
            
        }
        if (OVRInput.Get(OVRInput.Button.PrimaryIndexTrigger) && currAmmo <= 0)
        {
            Debug.Log("Out of Ammo");
        }

        if (OVRInput.GetDown(OVRInput.RawButton.Y))
        {
            SwitchBulltets();
        }
        if (OVRInput.GetDown(OVRInput.RawButton.X))
        {
            SwitchFireMode();
        }
    }


    void ReduceAmmo()
    {
        currAmmo--;
        currAmmo = Mathf.Clamp(currAmmo, 0, maxAmmo);
    }

    void RegainAmmo()
    {
        currAmmo += ammoReturn;
        currAmmo = Mathf.Clamp(currAmmo, 0, maxAmmo);
    }

    void SwitchFireMode()
    {
        fullAutoMode = !fullAutoMode;
        if (fullAutoMode == true)
        {
            shootTime = fullAutoTime;
        }
        else
        {
            shootTime = semiAutoTime;
        }
    }

    void SwitchBulltets()
    {
        if (!green.activeSelf)
        {
            red.SetActive(false);
            green.SetActive(true);
        }
        else
        {
            green.SetActive(false);
            red.SetActive(true);
        }
    }

    void Shoot()
    {
            RaycastHit hit;
            if (Physics.Raycast(spawnPoint.position, transform.TransformDirection(Vector3.forward), out hit, Mathf.Infinity, layerMask))
            {
                if (green.activeSelf)
                {
                    Instantiate(greenBullet, spawnPoint.position, transform.rotation * Quaternion.Euler(0, 90, 0));
                }
                if (red.activeSelf)
                {
                    Instantiate(redBullet, spawnPoint.position, transform.rotation * Quaternion.Euler(0, 90, 0));
                }
                if (!green.activeSelf && !red.activeSelf)
                {
                    Instantiate(waveBullet, spawnPoint.position, transform.rotation * Quaternion.Euler(0, 90, 0));
                }
                Debug.DrawRay(spawnPoint.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.yellow);
                ReduceAmmo();
                Debug.Log("Did Hit");
            }
            else
            {
                if (green.activeSelf)
                {
                    Instantiate(greenBullet, spawnPoint.position, transform.rotation * Quaternion.Euler(0, 90, 0));
                }
                if (red.activeSelf)
                {
                    Instantiate(redBullet, spawnPoint.position, transform.rotation * Quaternion.Euler(0, 90, 0));
                }
                if (!green.activeSelf && !red.activeSelf)
                {
                    Instantiate(waveBullet, spawnPoint.position, transform.rotation * Quaternion.Euler(0, 90, 0));
                }
                Debug.DrawRay(spawnPoint.position, transform.TransformDirection(Vector3.forward) * 1000, Color.red);
                ReduceAmmo();
                Debug.Log("Did not Hit");
            }
            currTime = 0;
    }

    IEnumerator OneShot()
    {
        Shoot();
        canShoot = false;
        yield return new WaitForSeconds(0.01f);
    }
}
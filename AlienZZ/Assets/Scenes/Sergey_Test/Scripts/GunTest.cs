using UnityEngine;

public class GunTest : MonoBehaviour
{
    public Transform spawnPoint; //Point the raycast will originate from
    public LayerMask layerMask; //The layer mask that detects enemy
    public float damageValue = 0;
    [Header("Ammo")]
    public int currAmmo = 10;
    public int maxAmmo = 20;
    public int ammoReturn = 3;
    [Header("Weapon Firing")]
    public bool canShoot = false;
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
    private void Awake()
    {
        green = GetComponentInChildren<ID_Green>().gameObject;
        red = GetComponentInChildren<ID_Red>().gameObject;
        greenBullet = Resources.Load(("Prefabs/PlasmaBulletGreen"), typeof(GameObject)) as GameObject;
        redBullet = Resources.Load(("Prefabs/PlasmaBulletRed"), typeof(GameObject)) as GameObject;
        waveBullet = Resources.Load(("Prefabs/WaveBullet"), typeof(GameObject)) as GameObject;
        fullAutoTime = 0.1f;
    }

    void Start()
    {
        //currTime = shootTime;
        //SwitchFireMode();
        damageValue = 1;
        red.SetActive(false);
    }

    void Update()
    {
        if (fullAutoMode)
        {
            if (Input.GetKey(KeyCode.Mouse0) && canShoot && currAmmo > 0)
            {
                Shoot();
            }
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.Mouse0) && canShoot && currAmmo > 0)
            {
                Shoot();
            }
        }

        if (Input.GetKey(KeyCode.Mouse0) && currAmmo <= 0)
        {
            Debug.Log("Out of Ammo");
        }
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            SwitchFireMode();
        }
        if (Input.GetKey(KeyCode.G) && !green.activeSelf)
        {
            red.SetActive(false);
            green.SetActive(true);
        }
        if (Input.GetKey(KeyCode.R) && !red.activeSelf)
        {
            green.SetActive(false);
            red.SetActive(true);
        }
    }

    private void FixedUpdate()
    {
        currTime += Time.deltaTime;
        if (currTime >= shootTime)
        {
            canShoot = true;
        }
        else
        {
            //currTime += Time.deltaTime;
            canShoot = false;
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

    void Shoot()
    {
        RaycastHit hit;
        if (Physics.Raycast(spawnPoint.position, transform.TransformDirection(Vector3.forward), out hit, Mathf.Infinity, layerMask))
        {
            if (green.activeSelf)
            {
                //Instantiate(greenBullet, spawnPoint.position, transform.rotation);
                Instantiate(waveBullet, spawnPoint.position, transform.rotation);
            }
            if (red.activeSelf)
            {
                Instantiate(redBullet, spawnPoint.position, transform.rotation);
            }
            Debug.DrawRay(spawnPoint.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.yellow);
            RegainAmmo();
            Debug.Log("Did Hit");
        }
        else
        {
            if (green.activeSelf)
            {
                //Instantiate(greenBullet, spawnPoint.position, transform.rotation);
                Instantiate(waveBullet, spawnPoint.position, transform.rotation);
            }
            if (red.activeSelf)
            {
                Instantiate(redBullet, spawnPoint.position, transform.rotation);
            }
            Debug.DrawRay(spawnPoint.position, transform.TransformDirection(Vector3.forward) * 1000, Color.red);
            ReduceAmmo();
            Debug.Log("Did not Hit");
        }
        currTime = 0;
    }
}
using UnityEngine;

public class ENemyHealth : Health
{
    GunTestVR gtScript;
    UI_Info uiScript;
    public float pointTimer;
    public GameObject floatingTextPrefab;
    public ESpawner spawner;
    public ScoreScript scoreS;
    public ESpawner eSpawner;
    public int points;
    GameObject laserDeathEffect;
    GameObject gpDeathEffect;
    GameObject rpDeathEffect;
    Transform enemyPos;
    GameObject bulletType = null;
    public bool enemyHit;

    private void Awake()
    {
        currHealth = 3;
        spawner = GameObject.FindGameObjectWithTag("Spawner").GetComponent<ESpawner>();
        scoreS = GameObject.FindGameObjectWithTag("Score").GetComponent<ScoreScript>();
        eSpawner = FindObjectOfType<ESpawner>();
        uiScript = FindObjectOfType<UI_Info>();
        laserDeathEffect = Resources.Load(("Prefabs/EnemyDeathEffect"), typeof(GameObject)) as GameObject;
        gpDeathEffect = Resources.Load(("Prefabs/EnemyDeathGPEffect"), typeof(GameObject)) as GameObject;
        rpDeathEffect = Resources.Load(("Prefabs/EnemyDeathRPEffect"), typeof(GameObject)) as GameObject;
        pointTimer = 0;
        enemyHit = false;
    }

    public override void TakeDamage(float damageAmount)
    {
        base.TakeDamage(damageAmount);
        if (currHealth <= 0)
        {
            if (gameObject.layer == 8 || gameObject.tag == "GreenEnemy")
            {
                GameManager.gameManager.greenDeaths++;
            }
            GameManager.gameManager.hits++;
            pointTimer++;
            eSpawner.killCount++;
            eSpawner.totalToSpawn -= 1;
            eSpawner.SpawnGreen();
            CallMulti();
            DeathEffect();
            Destroy(gameObject);
        }
        if (floatingTextPrefab)
        {
            ShowFloatingText();
        }
    }

    void ShowFloatingText()
    {
        var go = Instantiate(floatingTextPrefab, transform.position, Quaternion.identity, transform);
        go.GetComponent<TextMesh>().text = damageTaken.ToString();
    }

    private void Update()
    {
        pointTimer += 1 * Time.deltaTime;
    }

    private void FixedUpdate()
    {
        enemyPos = transform;
    }

    private void OnCollisionEnter(Collision collision)
    {
        bulletType = collision.collider.gameObject;
        if (collision.collider.CompareTag("RedBullet") && gameObject.tag == "RedEnemy")
        {
            //DeathEffect();
            TakeDamage(5);
            enemyHit = true;
        }
        else if (collision.collider.CompareTag("GreenBullet") && gameObject.tag == "GreenEnemy")
        {
            TakeDamage(5);
            enemyHit = true;
        }
        if (collision.collider.CompareTag("GreenBullet") && gameObject.tag == "RedEnemy")
        {
            
        }
        if (collision.collider.CompareTag("RedBullet") && gameObject.tag == "GreenEnemy")
        {
            // Player Loses Health Here
        }
    }

    void DeathEffect()
    {
        if (bulletType.GetComponent<PlasmaBullet>())
        {
            if (gameObject.tag == "RedEnemy")
            {
                Instantiate(rpDeathEffect, enemyPos.position, Quaternion.identity);
            }
            if (gameObject.tag == "GreenEnemy")
            {
                Instantiate(gpDeathEffect, enemyPos.position, Quaternion.identity);
            }
        }
        else
        {
            Instantiate(laserDeathEffect, enemyPos.position, Quaternion.identity);
        }

            //int random = Random.Range(1, 4);
            //if (random == 1)
            //    Instantiate(deathEffect, enemyPos.position, Quaternion.identity);
            //if (random == 2)
            //if (random == 3)
            //else
            //    Instantiate(deathEffect, enemyPos.position, Quaternion.identity);
        
    }

    void CallMulti()
    {
        if (pointTimer <= 5)
        {
            points = 100;
            scoreS.Multi(points);
        }

        if (pointTimer >= 6 && pointTimer <= 19)
        {
            points = 75;
            scoreS.Multi(points);
        }

        if (pointTimer >= 20 && pointTimer <= 30)
        {
            points = 50;
            scoreS.Multi(points);
        }
        if (pointTimer >= 31)
        {
            points = 25;
            scoreS.Multi(points);
        }
    }
}
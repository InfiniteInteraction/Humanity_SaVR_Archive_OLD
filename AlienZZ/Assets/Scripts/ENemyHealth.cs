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
    private void Awake()
    {
        currHealth = 3;
        spawner = GameObject.FindGameObjectWithTag("Spawner").GetComponent<ESpawner>();
        scoreS = GameObject.FindGameObjectWithTag("Score").GetComponent<ScoreScript>();
        eSpawner = FindObjectOfType<ESpawner>();
        uiScript = FindObjectOfType<UI_Info>();

        pointTimer = 0;
    }

    public override void TakeDamage(float damageAmount)
    {
        base.TakeDamage(damageAmount);
        if (currHealth <= 0)
        {
            //uiScript.alienCount++;
            pointTimer++;
            eSpawner.killCount++;
            eSpawner.totalToSpawn -= 1;
            eSpawner.RemoveEnemy();
            eSpawner.SpawnGreen();
            CallMulti();
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

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("RedBullet") || collision.collider.tag == "GreenBullet")

            TakeDamage(gtScript.damageValue);
    }

    void CallMulti()
    {
        if (pointTimer <= 4)
        {
            points = 10;
            scoreS.Multi(points);
        }

        if (pointTimer >= 5 && pointTimer <= 9) ;
        {
            points = 10;
            scoreS.Multi(points);
        }

        if (pointTimer >= 10 )
        {
            points = 10;
            scoreS.Multi(points);
        }
    }
}
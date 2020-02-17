using UnityEngine;

public class ENemyHealth : Health
{
    UI_Info uiScript;
    public float increment;
    public GameObject floatingTextPrefab;
    public ESpawner spawner;
    public ScoreScript scoreS;
    public ESpawner eSpawner;
    private void Awake()
    {
        currHealth = 3;
        spawner = GameObject.FindGameObjectWithTag("Spawner").GetComponent<ESpawner>();
        scoreS = GameObject.FindGameObjectWithTag("Score").GetComponent<ScoreScript>();
        eSpawner = FindObjectOfType<ESpawner>();
        uiScript = FindObjectOfType<UI_Info>();

        increment = 0;
    }

    public override void TakeDamage(float damageAmount)
    {
        base.TakeDamage(damageAmount);
        if (currHealth <= 0)
        {
            //uiScript.alienCount++;
            increment++;
            scoreS.Multi();
            eSpawner.killCount++; 
            eSpawner.totalToSpawn -= 1;
            eSpawner.RemoveEnemy();
            eSpawner.SpawnGreen();     
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
        increment += 1 * Time.deltaTime;
    }
}
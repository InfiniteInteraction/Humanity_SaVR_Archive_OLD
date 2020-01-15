using UnityEngine;

public class ENemyHealth : Health
{
    public GameObject floatingTextPrefab;
    public ESpawner spawner;
    public ScoreScript scoreS;
    private void Awake()
    {
        currHealth = 3;
        spawner = GameObject.FindGameObjectWithTag("Spawner").GetComponent<ESpawner>();
        scoreS = GameObject.FindGameObjectWithTag("Score").GetComponent<ScoreScript>();
    }

    public override void TakeDamage(float damageAmount)
    {
        base.TakeDamage(damageAmount);
        if (currHealth <= 0)
        {
            scoreS.scoreValue += 10;
            spawner.SpawnEnemy();
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
}
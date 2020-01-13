using UnityEngine;

public class ENemyHealth : Health
{
    public GameObject floatingTextPrefab;
    public ESpawner spawner;
    private void Awake()
    {
        currHealth = 3;
        spawner = GameObject.FindGameObjectWithTag("Spawner").GetComponent<ESpawner>();
    }

    public override void TakeDamage(float damageAmount)
    {
        base.TakeDamage(damageAmount);
        if (currHealth <= 0)
        {
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
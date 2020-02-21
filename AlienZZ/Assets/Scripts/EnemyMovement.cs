using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour
{
    NavMeshAgent agent;
    int dest;
    public float distanceToPlayer = 5f;
    float timer;
    public float waitTime;
    public float facePlayerFact;
    [SerializeField]
    int stage;
    bool here;
    public GameObject player;
    public GameObject greenPos;
    GameObject blast;
    public bool VR = false;

    public virtual void Awake()
    {
        waitTime = 1f;
        player = GameObject.FindGameObjectWithTag("Player"); 
    }
    public virtual void OnEnable()
    {
        timer = waitTime;
        agent = GetComponent<NavMeshAgent>();

        here = false;
        agent.autoBraking = false;
        stage = 0;
    }

    public virtual void Update()
    {
        greenPos = GameObject.FindGameObjectWithTag("PPoint");
        ChasePlayer();
        Hurt();
        Vector3 direction = (player.transform.position - transform.position).normalized;
        Quaternion lookRot = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRot, Time.deltaTime * facePlayerFact);
    }


    public virtual void ChasePlayer()
    {
        if (tag == "RedEnemy")
        {
            float distance = Vector3.Distance(player.transform.position, transform.position);
            if (distance >= distanceToPlayer)
            {
                agent.SetDestination(player.transform.position);
            }
            else if (agent.isActiveAndEnabled && distance <= distanceToPlayer)
            {
                agent.updatePosition = false;
                here = true;
            }
        }

        else if(tag == "GreenEnemy")
        {
            agent.SetDestination(greenPos.transform.position);
            Invoke("SpawnPass", 10);
        }
    }

    public virtual void Hurt()
    {
        switch (stage)
        {
            case 0:
                if (here == true)
                {
                    stage = 1;
                }

                break;

            case 1:
                Instantiate(blast, transform.position, transform.rotation * Quaternion.Euler(0, 90, 0)); ;
                if (timer <= 0)
                {
                    stage = 2;
                }
                else
                {
                    timer -= Time.deltaTime;
                }

                break;

            case 2:
                gameObject.GetComponentInChildren<Renderer>().material.color = Color.red;
                break;
        }
    }
    void SpawnPass()
    {
        Destroy(gameObject);
    }
}
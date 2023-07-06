using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class AIscript : MonoBehaviour
{
    public NavMeshAgent enemy;
    public ParticleSystem enemyDeathEffect;
    //public Rigidbody enemyrb;

    GameObject Enemy;

    public Transform player;
    [SerializeField] public Transform Base;
    

    public bool baseExists;
    public bool playerInRange;

    public static bool SphereCast;

    public float maxDistance = 0.1f, radius = 12.5f;
    public float attackRadius = 1.0f;
    private float nextTimeToAttack = 0f, attackRate = 10.0f;


    public int health = 100, zdamage = 10;


    public LayerMask layerMask;

    private Vector3 origin;
    private Vector3 direction;
    private Vector3 destination;
    private PlayerManager playerManager;

    bool deathPlayed = false;

    // Start is called before the first frame update
    void Awake()
    {
        enemy = GetComponent<NavMeshAgent>();

        health = 100;

        //enemyrb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        origin = transform.position;
        direction = transform.forward;
        RaycastHit hit;

        if (Physics.SphereCast(origin, attackRadius, direction, out hit, maxDistance, layerMask, QueryTriggerInteraction.UseGlobal))
        {
            if (hit.collider.tag == "Player" || hit.collider.tag == "Base" && Time.time >= nextTimeToAttack)
            {
                nextTimeToAttack = Time.time + 5f / attackRate;
                Attack();
            }
        }


        /*Vector3 moveDirection = (destination - this.transform.position).normalized;
        enemyrb.MovePosition(moveDirection);*/

        // rigidbody.velocity
        // Vector3 moveDirection = (destination - this.transform.position).normalized;

        

        if (health <= 0 && !deathPlayed)
        {
            StartCoroutine("Die");
        }   

        playerInRange = Physics.CheckSphere(this.transform.position, radius, layerMask);
        

        if (playerInRange == false)
        {
            enemy.destination = Base.position;
        }
        else if (playerInRange == true)
        {
            enemy.destination = player.position;
        }
    }
    void Attack()
    {
        playerManager = GetComponent<PlayerManager>();
        playerManager.pHealth -= zdamage;
    }
    
    IEnumerator Die()
    {
        gameObject.GetComponent<CapsuleCollider>().enabled = false;
        gameObject.GetComponent<MeshRenderer>().enabled = false;
        gameObject.GetComponent<NavMeshAgent>().enabled = false;
        enemyDeathEffect.Play();
        deathPlayed = true;

        yield return new WaitForSeconds(5);
        Destroy(gameObject);

    }
}

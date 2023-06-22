using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class AIscript : MonoBehaviour
{
    public NavMeshAgent enemy;
    //public Rigidbody enemyrb;

    public Transform player;
    [SerializeField] public Transform Base;
    

    public bool baseExists;
    public bool playerInRange;

    public static bool SphereCast;

    public float radius = 12.5f;
    public float maxDistance = 0.1f;

    public int health = 100;
    private int currentHealth;

    public LayerMask layerMask;

    private Vector3 origin;
    private Vector3 direction;
    private Vector3 destination;
    


    // Start is called before the first frame update
    void Awake()
    {
        enemy = GetComponent<NavMeshAgent>();

        health = 100;

        //enemyrb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {/*
        origin = transform.position;
        direction = transform.forward;
        RaycastHit hit;

        if (Physics.SphereCast(origin, radius, direction, out hit, maxDistance, layerMask, QueryTriggerInteraction.UseGlobal))
        {
            if (hit.collider.tag == "Player")
            {
                playerInRange = true;
            }
            else
            {
                playerInRange = false;
            }

        }*/

         
        /*Vector3 moveDirection = (destination - this.transform.position).normalized;
        enemyrb.MovePosition(moveDirection);*/

        // rigidbody.velocity
        // Vector3 moveDirection = (destination - this.transform.position).normalized;

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
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class AIscript : MonoBehaviour
{
    public NavMeshAgent enemy;


    public Transform player;
    [SerializeField] public Transform Base;

    public bool baseExists;
    public bool playerInRange;

    public static bool SphereCast;

    public float radius;
    public float maxDistance;

    public LayerMask layerMask;

    private Vector3 origin;
    private Vector3 direction;

    // Start is called before the first frame update
    void Awake()
    {
        enemy = GetComponent<NavMeshAgent>();
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

        playerInRange = Physics.CheckSphere(this.transform.position, radius, layerMask);

        if (playerInRange == false)
        {
            enemy.destination = Base.position;
        }
        else
        {
            if (playerInRange == true)
            {
                enemy.destination = player.position;
            }
               
        }
        
    }
}

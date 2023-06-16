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

    // Start is called before the first frame update
    void Awake()
    {
        enemy = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    private void Update()
    {

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

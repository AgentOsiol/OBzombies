using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class AIscript : MonoBehaviour
{
    public NavMeshAgent Enemy;
    public Transform Player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Enemy.SetDestination(transform.position = transform.position);
    }
}

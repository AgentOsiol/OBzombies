using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class AIscript : MonoBehaviour
{
    public NavMeshAgent Enemy;

    public Transform Player;
    public Transform Base;

    public string BaseExists;

    
    // Start is called before the first frame update
    void Start()
    {
        Enemy = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}